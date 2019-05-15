using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthPickUp : MonoBehaviour {


	void Update ()
    {
		
	}

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Player"))
        {
            PlayerController.PlayerHealth += 20;

            Destroy(this.gameObject);

            print(PlayerController.PlayerHealth);
        }
    }
}
