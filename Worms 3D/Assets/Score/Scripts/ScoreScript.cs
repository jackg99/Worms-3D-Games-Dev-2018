using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.UI;

public class ScoreScript : MonoBehaviour
{
    //Variable that keeps track of the score
    int current_Score = 15;

    //Initialize the Text object
    Text scoreText;
    //Initialize the RectTranfrom object
    RectTransform position;

    void Start()
    {
        //Creates a Text object
        scoreText = gameObject.GetComponentInChildren<Text>();
        //Creates a RectTransform object
        position = scoreText.GetComponentInChildren<RectTransform>();
        //Calls the metjod to set the position of the text for the score
        setPosition(420, 270, 0);   
    }

    //This method sets the colour of the text of the score
    public void setTextColour(int colorCode)
    {
        Color orange = new Color(255, 165, 0);

        switch (colorCode)
        {
            case 1:
                scoreText.color = Color.blue;
                break;
            case 2:
                scoreText.color = orange;
                break;
            case 3:
                scoreText.color = Color.green;
                break;
            case 4:
                scoreText.color = Color.magenta;
                break;
            default:
                scoreText.color = Color.cyan;
                break;
        }
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
        scoreText.text = "Score \n" + current_Score.ToString();
    }
}
