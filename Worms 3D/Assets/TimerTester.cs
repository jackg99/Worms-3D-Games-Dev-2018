using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimerTester : MonoBehaviour {
    Timer ourTimer;
	// Use this for initialization
	void Start () {
       
	}
	
	// Update is called once per frame
	void Update () {


        if (Input.GetKeyDown(KeyCode.Space))
        {
            ourTimer = gameObject.AddComponent<Timer>();
            ourTimer.StartTimer(0);
        }

        if (ourTimer)  print(ourTimer.current_Time);
	}
}
