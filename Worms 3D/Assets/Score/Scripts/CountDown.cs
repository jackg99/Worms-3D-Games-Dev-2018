//Sean Conway Arcon Teahan Dean George
// To use this script create a canvas then create a text object and paste it to the canvas
// Then create a gameobject and drag this script on to that gameobject 
// the drag the text object into the box in the TimeandDisplay script
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CountDown : MonoBehaviour
{
    public Text GameTimerText;
    float gameTimer = 75f;


    private void Update()
    {
        gameTimer -= Time.deltaTime;

        int seconds = (int)(gameTimer % 60);
        int minutes = (int)(gameTimer / 60) % 60;

        string timerString = string.Format("{0:00}:{1:00}", minutes, seconds);

        GameTimerText.text = timerString;
    }
}
