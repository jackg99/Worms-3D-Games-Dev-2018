//Sean Conway Arcon Teahan Dean George
// To use this script create a canvas then create a text object and paste it to the canvas
// Then create a gameobject and drag this script on to that gameobject 
// the drag the text object into the box in the TimeandDisplay script
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimeAndDisplayCountup : MonoBehaviour {
    public Text GameTimerText;
    float gameTimer = 0f;
    private bool started;
    float TargetTime;

    private void Update()
    {
        if (started)
            gameTimer += Time.deltaTime;

        //int seconds = (int)(gameTimer % 60);
        //int minutes = (int)(gameTimer / 60) % 60;

        //string timerString = string.Format("{0:00}:{1:00}",minutes,seconds);

        //GameTimerText.text = timerString;
    }

    internal void setDuration(float time)
    {
        TargetTime = time;
    }

    internal float relativePercentage()
    {
        return 100 *relative() ;
    }

    internal void startTimer()
    {
        gameTimer = 0;
        started = true;
    }

    internal float relative()
    {
        return gameTimer / TargetTime;
    }

    internal bool isOver()
    {
        return gameTimer > TargetTime;
    }
}
   
