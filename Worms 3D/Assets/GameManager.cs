     using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

    public static GameManager instance = null;
    public GameObject groundPrefab;
    public GameObject surroundingWallPrefab;
    public GameObject platformPrefab;
    public int xMaxBounds, xMinBounds, zMaxBounds, zMinBounds;


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
        spawnSurroundingWalls();
        generateFortress();
        //Instantiate(platformPrefab, new Vector3(0, 25, 225), Quaternion.Euler(90,0,0));

    }

    // Update is called once per frame
    void Update () {
		
	}

    void createWall(Vector3 position, float height, float width, float depth, Vector3 lookAt)

    {
        GameObject ourWall = GameObject.CreatePrimitive(PrimitiveType.Cube);
        ourWall.transform.position = position + (height/2) * Vector3.up;
        ourWall.transform.localScale = new Vector3(width, height, depth);
        ourWall.transform.LookAt(lookAt);
        ourWall.AddComponent<Health>();

    }
    public void spawnSurroundingWalls() // creates surrounding walls
    {
        createWall(new Vector3(0, 0, 250), 50, 500, 1, new Vector3(0, 25, 0));
        createWall(new Vector3(0, 0, -250), 50, 500, 1, new Vector3(0, 25, 0));
        createWall(new Vector3(250, 0, 0), 50, 500, 1, new Vector3(0, 25, 0));
        createWall(new Vector3(-250, 0, 0), 50, 500, 1, new Vector3(0, 25, 0));



    }

    public void generateFortress()
    {

        createWall(new Vector3(50, 0, 0), 30, 100, 1, new Vector3(0, 15, 0));
        createWall(new Vector3(0, 0, 50), 30, 100, 1, new Vector3(0, 15, 0));
        createWall(new Vector3(0, 0, -50), 30, 100, 1, new Vector3(0, 15, 0));
        createWall(new Vector3(-50, 0, 0), 30, 95, 1, new Vector3(0, 15, 0));
    }

    
}
