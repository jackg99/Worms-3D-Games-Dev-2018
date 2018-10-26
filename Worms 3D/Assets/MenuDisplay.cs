using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuDisplay : MonoBehaviour {

    FloatingDisplay start;
    FloatingDisplay exit;
    private AssetBundle myLoadedAssetBundle;
    private string[] scenePaths;

    // Use this for initialization
    void Start () {
        //myLoadedAssetBundle = AssetBundle.LoadFromFile("PlayerControllerTest.unity");
        //scenePaths = myLoadedAssetBundle.GetAllScenePaths();

        start = gameObject.AddComponent <FloatingDisplay>();
        start.setDisplay("Start Game");
        start.transform.localPosition = Vector3.up;

        exit = gameObject.AddComponent<FloatingDisplay>();
        exit.setDisplay("Exit game");
        exit.transform.localPosition = -Vector3.up;
    }
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown("n"))
        {
            start.setColour(2);
            //SceneManager.LoadScene(scenePaths[0], LoadSceneMode.Single);
        }

        if(Input.GetKeyDown("x"))
        {
            exit.setColour(4);
            Application.Quit();
        }
	}
}
