using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuDisplay : MonoBehaviour {

    GameObject start;
    GameObject exit;


    // Use this for initialization
    void Start () {
        start = new GameObject();
        MenuFloatingDisplay startDisp = start.AddComponent <MenuFloatingDisplay>();
        startDisp.setDisplay("Start Game");
        BoxCollider startCol =  start.gameObject.AddComponent<BoxCollider>();
        startCol.size = new Vector3(4, 1, 1);

        exit = new GameObject();
        MenuFloatingDisplay exitDisp = exit.AddComponent<MenuFloatingDisplay>();
        exitDisp.setDisplay("Exit Game");
        BoxCollider exitCol = exit.gameObject.AddComponent<BoxCollider>();
        exit.transform.position = 2f * -Vector3.up;
        exitCol.size = new Vector3(4, 1, 1);

    }
	
	// Update is called once per frame
	void Update () {
        RaycastHit hit;
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(ray, out hit))
        {
            MenuFloatingDisplay fd = hit.collider.gameObject.GetComponent<MenuFloatingDisplay>();
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
