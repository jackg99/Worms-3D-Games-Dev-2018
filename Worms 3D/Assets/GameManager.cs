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
        generateBattleground();
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
        //Creates fortress 1
        createWall(new Vector3(-202.5f, 0, -150), 20, 95, 1, new Vector3(-202.5f, 10, -200));
        createWall(new Vector3(-150, 0, -200), 20, 100, 1, new Vector3(-200, 10, -200));

        //Creates fortress 2
        createWall(new Vector3(-202.5f, 0, 150), 20, 95, 1, new Vector3(-202.5f, 10, 200));
        createWall(new Vector3(-150, 0, 200), 20, 100, 1, new Vector3(-200, 10, 200));

        //Creates fortress 3
        createWall(new Vector3(202.5f, 0, 150), 20, 95, 1, new Vector3(202.5f, 10, 200));
        createWall(new Vector3(150, 0, 200), 20, 100, 1, new Vector3(200, 10, 200));

        //Creates fortress 4
        createWall(new Vector3(202.5f, 0, -150), 20, 95, 1, new Vector3(202.5f, 10, -200));
        createWall(new Vector3(150, 0, -200), 20, 100, 1, new Vector3(200, 10, -200));
    }

    public void generateBattleground()
    {
        //create first pillar
        createWall(new Vector3(45, 0, 40), 20, 10, 1, new Vector3(45, 10, 45));
        createWall(new Vector3(40, 0, 45), 20, 10, 1, new Vector3(45, 10, 45));
        createWall(new Vector3(45, 0, 50), 20, 10, 1, new Vector3(45, 10, 45));
        createWall(new Vector3(50, 0, 45), 20, 10, 1, new Vector3(45, 10, 45));

        //create second pillar
        createWall(new Vector3(45, 0, -40), 20, 10, 1, new Vector3(45, 10, -45));
        createWall(new Vector3(40, 0, -45), 20, 10, 1, new Vector3(45, 10, -45));
        createWall(new Vector3(45, 0, -50), 20, 10, 1, new Vector3(45, 10, -45));
        createWall(new Vector3(50, 0, -45), 20, 10, 1, new Vector3(45, 10, -45));

        //create third pillar
        createWall(new Vector3(-45, 0, -40), 20, 10, 1, new Vector3(-45, 10, -45));
        createWall(new Vector3(-40, 0, -45), 20, 10, 1, new Vector3(-45, 10, -45));
        createWall(new Vector3(-45, 0, -50), 20, 10, 1, new Vector3(-45, 10, -45));
        createWall(new Vector3(-50, 0, -45), 20, 10, 1, new Vector3(-45, 10, -45));

        //create fourth pillar
        createWall(new Vector3(-45, 0, 40), 20, 10, 1, new Vector3(-45, 10, 45));
        createWall(new Vector3(-40, 0, 45), 20, 10, 1, new Vector3(-45, 10, 45));
        createWall(new Vector3(-45, 0, 50), 20, 10, 1, new Vector3(-45, 10, 45));
        createWall(new Vector3(-50, 0, 45), 20, 10, 1, new Vector3(-45, 10, 45));

        //create platform
        createWall(new Vector3(0, 20.5f, 0), 1, 100, 100, new Vector3(100000, 0, 0));//The bigger the x value for lookAt(), the flatter the platform will be

        //create first turret
        createWall(new Vector3(40, 21.5f, 30), 10, 20, 1, new Vector3(40, 26.5f, 40));
        createWall(new Vector3(30, 21.5f, 40), 10, 20, 1, new Vector3(40, 26.5f, 40));
        createWall(new Vector3(40, 21.5f, 50), 10, 20, 1, new Vector3(40, 26.5f, 40));
        createWall(new Vector3(50, 21.5f, 40), 10, 20, 1, new Vector3(40, 26.5f, 40));
        //create turret platform
        createWall(new Vector3(40, 30.5f, 40), 1, 20, 20, new Vector3(100000, 0, 0));//The bigger the x value for lookAt(), the flatter the platform will be

        //create second turret
        createWall(new Vector3(40, 21.5f, -30), 10, 20, 1, new Vector3(40, 26.5f, -40));
        createWall(new Vector3(30, 21.5f, -40), 10, 20, 1, new Vector3(40, 26.5f, -40));
        createWall(new Vector3(40, 21.5f, -50), 10, 20, 1, new Vector3(40, 26.5f, -40));
        createWall(new Vector3(50, 21.5f, -40), 10, 20, 1, new Vector3(40, 26.5f, -40));
        //create turret platform
        createWall(new Vector3(40, 30.5f, -40), 1, 20, 20, new Vector3(100000, 0, 0));//The bigger the x value for lookAt(), the flatter the platform will be

        //create third turret
        createWall(new Vector3(-40, 21.5f, -30), 10, 20, 1, new Vector3(-40, 26.5f, -40));
        createWall(new Vector3(-30, 21.5f, -40), 10, 20, 1, new Vector3(-40, 26.5f, -40));
        createWall(new Vector3(-40, 21.5f, -50), 10, 20, 1, new Vector3(-40, 26.5f, -40));
        createWall(new Vector3(-50, 21.5f, -40), 10, 20, 1, new Vector3(-40, 26.5f, -40));
        //create turret platform
        createWall(new Vector3(-40, 30.5f, -40), 1, 20, 20, new Vector3(-100000, 0, 0));//The bigger the x value for lookAt(), the flatter the platform will be

        //create fourth turret
        createWall(new Vector3(-40, 21.5f, 30), 10, 20, 1, new Vector3(-40, 26.5f, 40));
        createWall(new Vector3(-30, 21.5f, 40), 10, 20, 1, new Vector3(-40, 26.5f, 40));
        createWall(new Vector3(-40, 21.5f, 50), 10, 20, 1, new Vector3(-40, 26.5f, 40));
        createWall(new Vector3(-50, 21.5f, 40), 10, 20, 1, new Vector3(-40, 26.5f, 40));
        //create turret platform
        createWall(new Vector3(-40, 30.5f, 40), 1, 20, 20, new Vector3(-100000, 0, 0));//The bigger the x value for lookAt(), the flatter the platform will be

        //create first step
        createWall(new Vector3(60, 0, 0), 10, 100, 1, new Vector3(70, 5, 0));
        createWall(new Vector3(80, 0, 0), 10, 100, 1, new Vector3(70, 5, 0));
        createWall(new Vector3(70, 0, -50), 10, 20, 1, new Vector3(70, 5, 0));
        createWall(new Vector3(70, 0, 50), 10, 20, 1, new Vector3(70, 5, 0));
        //create turret platform
        createWall(new Vector3(70, 10, 0), 1, 100, 20, new Vector3(100000, 0, 0));//The bigger the x value for lookAt(), the flatter the platform will be
    }

    
}
