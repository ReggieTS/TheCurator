using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{

    // public Text healthText;

    private Rigidbody2D rb2d;
    private Animator Anim;
    private SpriteRenderer SpRend;
    public static int PlayerHealth = 100;
    public GameObject Enemy;
    private bool isGrounded = false;
    private bool Jump;
    public int EnemyOneDmg = 15;
    public Slider healthBar;

    private float JumpTimeCounter;
    public float JumpTime;
    private bool isJumping;

    private float attackDelay;

    public float timebtwattack;

    public bool Collided = false;



    [SerializeField]
    private float moveSpeed = 10f;
    [SerializeField]
    private float jumpForce = 100f;
    [SerializeField]
    private Transform groundCheck;
    [SerializeField]
    private float groundCheckRadius = 0.2f;







    // Jumping 
    void Awake()
    {
        rb2d = GetComponent<Rigidbody2D>();
        Anim = GetComponent<Animator>();
        SpRend = GetComponent<SpriteRenderer>();
        
        groundCheck = transform.Find("GroundCheck");


    }

    // Jumping
    void Update()

    {
        

        

        isGrounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, LayerMask.GetMask("Ground"));

        if (isGrounded == true && Input.GetKeyDown(KeyCode.Space))
        {
            isJumping = true;
            JumpTimeCounter = JumpTime;
            rb2d.AddForce(new Vector2(0f, jumpForce));
        }

        if (Input.GetKey(KeyCode.Space) && isJumping == true)
        {
            if(JumpTimeCounter > 0)
            { rb2d.AddForce(new Vector2(0f, jumpForce));
                JumpTimeCounter -= Time.deltaTime;

            } else
            {
                isJumping = false;
            } 
            
        }

        if (Input.GetKeyUp(KeyCode.Space))
        {
            isJumping = false;
        }

        healthBar.value = PlayerHealth;
    }
   
    
    

       
    


    public void maxHealth()
    {
        if(PlayerHealth > 100)
        {
            PlayerHealth = 100;
        }
    }


    public void AddHealth()
    {

        // healthText.text = "Health:" + PlayerHealth.ToString();
    }

    // Player Movement
    void FixedUpdate()

    {
        maxHealth();
        

        AddHealth();

        




        float horizontal = Input.GetAxis("Horizontal");
        Move(horizontal);
        Anim.SetFloat("Speed", Mathf.Abs(horizontal));
    }
    private void Move(float horizontal)
    {
        rb2d.velocity = new Vector2(horizontal * moveSpeed, rb2d.velocity.y);


        if (horizontal > 0)
        {
            SpRend.flipX = false;
        }

        else if (horizontal < 0)
        {
            SpRend.flipX = true;
        }

 
    }

    //Health

    void Start()
    {
        print(PlayerHealth);
        PlayerHealth = 100;
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.CompareTag("EnemyOne"))
        {

            PlayerHealth -= EnemyOneDmg;
        }

        if (PlayerHealth <= 0)
        {
            Destroy(gameObject);
            SceneManager.LoadScene("GameOver");
        }
    }

    
}

