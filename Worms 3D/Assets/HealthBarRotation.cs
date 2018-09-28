using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthBarRotation : MonoBehaviour {
    //string healthValue
    // Use this for initialization

    TextMesh ourText;
	void Start () {
        ourText = gameObject.AddComponent<TextMesh>();
        ourText.text = "100";
        ourText.anchor = TextAnchor.MiddleCenter;
        Font font = Resources.Load<Font>("Pixel Font - Tripfive/Tripfive-EX ");
        ourText.font = font;
	}
	

    public void setText(string newText)
    {
        ourText.text = newText;

    }
	// Update is called once per frame
	void Update ()
    {
        transform.rotation = Quaternion.LookRotation((-Camera.main.transform.position+transform.position).normalized);//Camera.main.transform.rotation;
	}
    public void setHealth ()
    {
        
    }
}
