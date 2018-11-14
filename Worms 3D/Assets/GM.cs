using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GM : MonoBehaviour
{

    public static GM instance = null;
    public GameObject groundPrefab;
    public GameObject surroundingWallPrefab;
    public GameObject platformPrefab;
    public GameObject wormPrefab;
    public int xMaxBounds, xMinBounds, zMaxBounds, zMinBounds;

    // Use this for initialization
    void Start()
    {

        if (instance == null)
        {
            instance = this;
        }

        else if (instance != null)
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
        //Instantiate(platformPrefab, new Vector3(0, 25, 225), Quaternion.Euler(90, 0, 0));
        Instantiate(wormPrefab, transform.position + Vector3.up, transform.rotation);

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void spawnWalls()
    {
        Instantiate(surroundingWallPrefab, new Vector3(0, 25, zMinBounds), Quaternion.identity);
        Instantiate(surroundingWallPrefab, new Vector3(0, 25, zMaxBounds), Quaternion.identity);
        Instantiate(surroundingWallPrefab, new Vector3(xMinBounds, 25, 0), Quaternion.Euler(0, 90, 0));
        Instantiate(surroundingWallPrefab, new Vector3(xMaxBounds, 25, 0), Quaternion.Euler(0, 90, 0));
    }
}
