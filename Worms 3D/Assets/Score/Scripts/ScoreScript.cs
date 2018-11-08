using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.UI;

public class ScoreScript : MonoBehaviour
{
    //string current_display_Text = "Score: \n";
    //Variable that keeps track of the score
    int current_Score = 15;
    //Initialize the Text object
    Text scoreText;
    //Initialize the RectTranfrom object
    RectTransform position;
    //Will set the TextMesh to active or inactive
    bool _isActive = false;


    void Start()
    {
        //Creates a Text object
        scoreText = gameObject.GetComponentInChildren<Text>();
        //Creates a RectTransform object
        position = scoreText.GetComponentInChildren<RectTransform>();
        //Calls the metjod to set the position of the text for the score
        setPosition(550, 260, 0);
    }

    //This method increments the score (for testting purpose only)
    public void scoreIncrease()
    {
        current_Score += 5;
    }

    public void setPosition(int x, int y, int z)
    {
        Vector3 distance = new Vector3(x, y, z);
        position.Translate(distance);
    }


    void Update()
    {
        /*//Shows the score
         

        if (_isActive) scoreText.text = "Score \n" + current_Score.ToString();
        else
            scoreText.text = "";*/

        scoreText.text = "Score: \n" + current_Score.ToString();

    }
}
