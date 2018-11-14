using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallTest : MonoBehaviour {

    public Object WallPrefab;
    wall myWall;

	// Use this for initialization
	void Start () {
        myWall = gameObject.GetComponent<wall>();

        //if (Input.GetKeyDown(KeyCode.Q))
        //{
        //    Instantiate(WallPrefab);
        //}

    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
