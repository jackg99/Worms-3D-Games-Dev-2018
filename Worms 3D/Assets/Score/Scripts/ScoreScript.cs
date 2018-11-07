using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.UI;

public class ScoreScript : MonoBehaviour
{
    string current_display_Text = "Score /n 15";
    //Variable that keeps track of the score
    int current_Score = 15;
    //Initialize the Text object
    TextMesh scoreText;
    //Initialize the RectTranfrom object
    RectTransform position;
    bool _isActive = false;
    void Start()
    {
        //Creates a Text object
        scoreText = gameObject.GetComponentInChildren<TextMesh>();
        //Creates a RectTransform object
        position = scoreText.GetComponentInChildren<RectTransform>();
        //Calls the metjod to set the position of the text for the score
        setPosition(520, 210, 0);
    }


  


    //This method increments the score
    public void scoreIncrease()
    {
        current_Score += 5;
    }

    //This method sets the position of the text of the score
    public void setPosition(int x, int y, int z)
    {
        Vector3 distance = new Vector3(x, y, z);
        position.Translate(distance);
    }

    public void setFontSize(int size)
    {
        scoreText.fontSize = size;
    }

    void Update()
    {
        //Shows the score

        if (_isActive) scoreText.text = "Score \n" + current_Score.ToString();
        else
            scoreText.text = "";

    }
}
