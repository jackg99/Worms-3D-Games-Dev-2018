using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuDisplay : MonoBehaviour {

    GameObject start;
    GameObject exit;


    // Use this for initialization
    void Start () {
        //myLoadedAssetBundle = AssetBundle.LoadFromFile("PlayerControllerTest.unity");
        //scenePaths = myLoadedAssetBundle.GetAllScenePaths();

        start = new GameObject();
        FloatingDisplay startDisp = start.AddComponent <FloatingDisplay>();
        startDisp.setDisplay("Start Game");
        Collider startCol =  start.gameObject.AddComponent<BoxCollider>();

        exit = new GameObject();
        exit.transform.position = 2 * -Vector3.up;
        FloatingDisplay exitDisp = exit.AddComponent<FloatingDisplay>();
        exitDisp.setDisplay("Exit Game");
        Collider exitCol = exit.gameObject.AddComponent<BoxCollider>();

        
    }
	
	// Update is called once per frame
	void Update () {
        RaycastHit hit;
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(ray, out hit))
        {
            FloatingDisplay fd = hit.collider.gameObject.GetComponent<FloatingDisplay>();
            if (fd)
            {
                fd.setColour(2);
            }
        }

            Debug.DrawRay(Camera.main.ScreenPointToRay(Input.mousePosition).origin, Camera.main.ScreenPointToRay(Input.mousePosition).direction * 100);
        if (Input.GetMouseButtonDown(0))
        {
            if (Physics.Raycast(ray, out hit))
            {
                if (hit.transform.gameObject == start)
                    SceneManager.LoadScene("PlayerControllerTest", LoadSceneMode.Single);
                else if (hit.transform.gameObject == exit)
                    print("Quitting");//Application.Quit();
            }
        }
	}
}
