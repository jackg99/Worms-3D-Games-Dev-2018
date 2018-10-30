using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreTest : MonoBehaviour {

    //Initial the score object
    ScoreScript ourScore;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

        if (Input.GetKeyDown(KeyCode.Space))
        {
            ourScore = gameObject.AddComponent<ScoreScript>();
            ourScore.scoreIncrease();
        }

    }
}
