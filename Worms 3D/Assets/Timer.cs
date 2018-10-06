//Sean Conway Arcon Teahan Dean George 
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Timer : MonoBehaviour {
   public float current_Time = 0;
    bool hasStarted = false;
    public System.String timertext;

    


    // Use this for initialization
    void Start () {
		
	}


    public void StartTimer()
    {
        hasStarted = true;
        current_Time = 0;
    }

    internal void StartTimer(int v)
    {
        throw new NotImplementedException();
    }





    // Update is called once per frame
    void Update () {
        current_Time += Time.deltaTime;
        timertext = current_Time + "Time: ";
	}
}
