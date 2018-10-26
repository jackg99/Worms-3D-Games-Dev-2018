using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.UI;

public class ScoreScript : MonoBehaviour {
    //Initializating variables
   int current_Score = 15;
     // private System.String scoreText;
    Text scoreText;
	// Use this for initialization
	void Start () {
        scoreText = gameObject.GetComponentInChildren<Text>();
        if (scoreText) print("yeee"); else print("nnnnn");

        //scoreText.text = "Score \n" + current_Score.ToString();
	}


    public void scoreIncrease()
    {
        current_Score += 5;
    }
	
	// Update is called once per frame
	void Update () {
        scoreText.text = "Score \n" + current_Score.ToString();
    }
}
