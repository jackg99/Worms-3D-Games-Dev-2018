using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.UI;

public class ScoreScript : MonoBehaviour
{
    //string current_display_Text = "Score: \n";
    //Variable that keeps track of the score
    int current_Score = 0;
    //Initialize the Text object
    Text scoreText;
    //Initialize the RectTranfrom object
    RectTransform position;
    //Calls playerController Scritp
    PlayerControl temp;
    //teamId
    int teamId;
    //teams
    int team1Score;
    int team2Score;
    int team3Score;
    int team4Score;

    void Start()
    {
        //Creates a Text object
        scoreText = gameObject.GetComponentInChildren<Text>();
        //Creates a RectTransform object
        position = scoreText.GetComponentInChildren<RectTransform>();
        //Calls the metjod to set the position of the text for the score
        setPosition(-51, -39, 0);
        //PlayerController
        temp = gameObject.AddComponent<PlayerControl>();
        
        
    }

    //This method increments the score (for testting purpose only)
    public void scoreIncrease()
    {
        switch (teamId)
        {
            case 0:
                team1Score += 5;
                break;
            case 1:
                team2Score += 3;
                break;
            case 2:
                team3Score += 2;
                break;
            case 3:
                team4Score += 6;
                break;
        }
    }

    public void setPosition(int x, int y, int z)
    {
        Vector3 distance = new Vector3(x, y, z);
        position.Translate(distance);
    }

    public void alteringScore()
    {
        Color orange = new Color(255, 165, 0);

        switch (teamId)
        {
            case 0:
                scoreText.color = Color.blue;
                scoreText.text = "Score: \n" + team1Score.ToString();
                break;
            case 1:
                scoreText.color = orange;
                scoreText.text = "Score: \n" + team2Score.ToString();
                break;
            case 2:
                scoreText.color = Color.green;
                scoreText.text = "Score: \n" + team3Score.ToString();
                break;
            case 3:
                scoreText.color = Color.magenta;
                scoreText.text = "Score: \n" + team4Score.ToString();
                break;
        }
    }


    void Update()
    {
        //teamId
        teamId = temp.setId();
        //Shows the score
        //scoreText.text = "Score: \n" + current_Score.ToString();
        alteringScore();
    }
}
