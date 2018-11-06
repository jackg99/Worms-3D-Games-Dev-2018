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
        //Calls the metjod to set the position of the text for the score 
        //ourScore.setPosition(420, 270, 0);
    }

    void Update()
    {
        //Calls the method to set the score
        setScore();
        //Calls the method to set the colour of the text
        ourScore.setTextColour(0);
        //Calls the method to set the size of the text
        ourScore.setFontSize(25);
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
