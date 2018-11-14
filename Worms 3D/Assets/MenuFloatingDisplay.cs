using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*To use, initialise a FloatingDisplay, and add the component to the object to be displayed above.
 */

public class MenuFloatingDisplay : MonoBehaviour
{
    //string healthValue
    // Use this for initialization
    public GameObject floatingDisplay;
    TextMesh ourText;


    // int display = System.Convert.ToInt32(myHealth.health);
    // string displayString = display.ToString();
    string displayString;
    private bool needToUpdateDisplay;

    void Awake()
    {



        //Original Floating Display Code

        floatingDisplay = new GameObject("Floating Display");
        floatingDisplay.transform.parent = transform;


        ourText = floatingDisplay.AddComponent<TextMesh>();
        ourText.text = displayString;
        ourText.anchor = TextAnchor.MiddleCenter;
        ourText.alignment = TextAlignment.Center;
        Font font = Resources.Load<Font>("Pixel Font - Tripfive/Fonts/Tripfive-EX");

        MeshRenderer rend = ourText.GetComponent<MeshRenderer>();
        rend.material = font.material;
        ourText.font = font;
    }

    public void setColour(int colorCode)
    {
        Color orange = new Color(255, 165, 0);

        switch (colorCode)
        {
            case 1:
                ourText.color = Color.blue;
                break;
            case 2:
                ourText.color = orange;
                break;
            case 3:
                ourText.color = Color.green;
                break;
            case 4:
                ourText.color = Color.magenta;
                break;
            default:
                ourText.color = Color.cyan;
                break;
        }

    }


    public void setDisplay(string newText)
    {
        if (ourText)
        {
            ourText.text = newText;
            needToUpdateDisplay = false;
        }
       
        else
        {
            needToUpdateDisplay = true;
            displayString = newText;
        }

    }
    // Update is called once per frame
    void Update()
    {
        if (needToUpdateDisplay)

            setDisplay(displayString);

        floatingDisplay.transform.rotation = Quaternion.LookRotation((-Camera.main.transform.position + floatingDisplay.transform.position).normalized);//Camera.main.transform.rotation;

        RaycastHit hit;
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        if (!Physics.Raycast(ray, out hit))
        {
            setColour(4);
        }
    }

    internal void manuallyDestroy()
    {
        Destroy(floatingDisplay);
        Destroy(this);
    }

}