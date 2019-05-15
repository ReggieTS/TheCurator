using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreController : MonoBehaviour {

    public static int score;
    public Text scoreText;

    void Start()
    {   
        score = 0;
    }


    void Update()
    {
        Addscore();
    }

 

    public void Addscore()
    {

        scoreText.text = "Score: " + score.ToString();
    }


}
