using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreTest : MonoBehaviour
{

    //Initial the score object
    ScoreScript ourScore;

    void Start()
    {
        //Calls the ScoreScript
        ourScore = gameObject.AddComponent<ScoreScript>();
    }

    void Update()
    {
        //Calls the method to set the score
        setScore();
    }

    //Increments the score each time you press space
    public void setScore()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            ourScore.scoreIncrease();
        }
    }
}
