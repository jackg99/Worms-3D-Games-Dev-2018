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
        spawnWalls();
        Instantiate(platformPrefab, new Vector3(0, 25, 225), Quaternion.Euler(90,0,0));

    }

    // Update is called once per frame
    void Update () {
		
	}

    void createWall(Vector3 position, float height, float width, float depth, Vector3 lookAt)

    {
        GameObject ourWall = GameObject.CreatePrimitive(PrimitiveType.Cube);
        ourWall.transform.position = position;
        ourWall.transform.localScale = new Vector3(width, height, depth);
        ourWall.transform.LookAt(lookAt);
        ourWall.AddComponent<Health>();

    }
    public void spawnWalls()
    {
        createWall(new Vector3(10, 0, 20), 3, 10, 1, new Vector3(0, 0, 0));

        Instantiate(surroundingWallPrefab, new Vector3(0, 50, zMinBounds), Quaternion.identity);
        Instantiate(surroundingWallPrefab, new Vector3(0, 50, zMaxBounds), Quaternion.identity);
        Instantiate(surroundingWallPrefab, new Vector3(xMinBounds, 50, 0), Quaternion.Euler(0, 90, 0));
        Instantiate(surroundingWallPrefab, new Vector3(xMaxBounds, 50, 0), Quaternion.Euler(0, 90, 0));
    }
}
