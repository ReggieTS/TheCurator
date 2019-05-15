﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialSigns : MonoBehaviour {
    public GameObject Sign;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
		
	}

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Player"))
        {
            Sign.SetActive(true);  
        }
    }

    private void OnTriggerExit2D(Collider2D col)
    {
        Sign.SetActive(false);
    }
}
