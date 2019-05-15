using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DeathBox : MonoBehaviour {

    public Collider2D Col;

    void Awake()
    {
        Col = GetComponent<Collider2D>();
        Col.isTrigger = true;
    }

	void OnTriggerEnter2D(Collider2D Col)
    {
        SceneManager.LoadScene("GameOver");
    }
}
