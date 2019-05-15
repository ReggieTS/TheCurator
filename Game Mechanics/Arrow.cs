using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arrow : MonoBehaviour {
    public float speed;
	
	void Update ()
    {
        transform.Translate(-transform.right * speed * Time.deltaTime);
	}

    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.CompareTag("Player"))
        {
            Destroy(this.gameObject, 0.1f);
        }
    }
}
