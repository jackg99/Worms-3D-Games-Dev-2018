using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

    public static GameManager instance = null;
    public GameObject groundPrefab;
    public GameObject surroundingWallPrefab;
    public GameObject platformPrefab;

    // Use this for initialization
    void Start () {

        if(instance == null)
        {
            instance = this;
        }

        else if(instance != null)
        {
            Destroy(gameObject);
        }

        DontDestroyOnLoad(gameObject);

        startGame();
		
	}

    void startGame()
    {
        print("Game Start");
        Instantiate(groundPrefab, new Vector3(0, 0, 0), Quaternion.identity);
        Instantiate(surroundingWallPrefab, new Vector3(0, 50, -250), Quaternion.identity);
        Instantiate(surroundingWallPrefab, new Vector3(0, 50, 250), Quaternion.identity);
        Instantiate(surroundingWallPrefab, new Vector3(-250, 50, 0), Quaternion.Euler(0,90,0));
        Instantiate(surroundingWallPrefab, new Vector3(250, 50, 0), Quaternion.Euler(0, 90, 0));
    }

    // Update is called once per frame
    void Update () {
		
	}
}
