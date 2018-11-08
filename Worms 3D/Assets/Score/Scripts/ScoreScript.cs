using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.UI;

public class ScoreScript : MonoBehaviour
{
    string current_display_Text = "Score: \n";
    //Variable that keeps track of the score
    int current_Score = 15;
    //Initialize the Text object
    TextMesh scoreText;
    //Will set the TextMesh to active or inactive
    bool _isActive = false;


    void Start()
    {
        //Creates a Text object
        scoreText = gameObject.GetComponentInChildren<TextMesh>();
       
    }

    //This method increments the score (for testting purpose only)
    public void scoreIncrease()
    {
        current_Score += 5;
    }
   
    void Update()
    {
        /*//Shows the score
         

        if (_isActive) scoreText.text = "Score \n" + current_Score.ToString();
        else
            scoreText.text = "";*/

        scoreText.text = current_display_Text + current_Score.ToString();

    }
}
