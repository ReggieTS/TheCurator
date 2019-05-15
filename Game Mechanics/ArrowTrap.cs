using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowTrap : MonoBehaviour {
    public GameObject Arrow;
    public Transform firePoint;

    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.CompareTag("Player"))
        {
            Instantiate(Arrow, firePoint.position, transform.rotation);
        }
    }
	

}
