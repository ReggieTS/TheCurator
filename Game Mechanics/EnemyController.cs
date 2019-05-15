using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour {


        public float speed;
        public GameObject Player;
        private float dazed;
        public float startDazed;
        public int points;

    private Animator Anim;


    private Transform target;

        public int Enemyhealth = 100;

        void Awake()
    {
        Anim = GetComponent<Animator>();
    }

        void Start()
        {
            target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();

            print(Enemyhealth);
        }


        void Update()
        {
            if (dazed <= 0)
            {
                speed = 1;
            }

            else
            {
                speed = 0;
                dazed -= Time.deltaTime;
            }

        if (GetComponent<Aggro>().agro)
        {
            Anim.SetBool("Agro", true);
        }
        else
        {
            Anim.SetBool("Agro", false);
        }

        }


        void FixedUpdate()
        {
            
            if (GetComponent<Aggro>().agro) 
                transform.position = Vector2.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
       
        if (target.position.x > transform.position.x)
            {

                transform.localScale = new Vector2(1, 1);
            }
            else if (target.position.x < transform.position.x)
            {

                transform.localScale = new Vector2(-1, 1);
            }

            if (Enemyhealth <= 0)
            {

                Destroy(gameObject);
            }


        

    }



        public void TakeDmg(int dmg)
        {
            dazed = startDazed;
            Enemyhealth -= dmg;
            Debug.Log("dmg Taken !");
        }
    }
    
