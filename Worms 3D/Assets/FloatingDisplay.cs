using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*To use, initialise a FloatingDisplay, and add the component to the object to be displayed above.
 */

public class FloatingDisplay : MonoBehaviour {
    //string healthValue
    // Use this for initialization
    GameObject floatingDisplay;
    TextMesh ourText;
    string display = "101";
    
	void Start () {



        floatingDisplay = new GameObject("Floating Display");
        floatingDisplay.transform.parent = transform;
        floatingDisplay.transform.localPosition += 1.65f * Vector3.up;


        ourText = floatingDisplay.AddComponent<TextMesh>();
        ourText.text = display;
        ourText.anchor = TextAnchor.MiddleCenter;
        ourText.alignment = TextAlignment.Center;
        Font font = Resources.Load<Font>("Pixel Font - Tripfive/Fonts/Tripfive-EX");
        
        MeshRenderer rend = ourText.GetComponent<MeshRenderer>();
        rend.material = font.material;
        ourText.font = font;
        ourText.color = Color.cyan;

        
    }
	

    public void setDisplay(string newText)
    {
        ourText.text = newText;

    }
	// Update is called once per frame
	void Update ()
    {
        floatingDisplay.transform.rotation = Quaternion.LookRotation((-Camera.main.transform.position+floatingDisplay.transform.position).normalized);//Camera.main.transform.rotation;
	}
    
}
