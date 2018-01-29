using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnMouseHoverTQ : MonoBehaviour {

    public string myString;
    public UnityEngine.UI.Text myTextTQ;

    public bool displayInfo;
    // Use this for initialization
    void Start()
    {
        myTextTQ = GameObject.Find("Hover_text_TQ").GetComponent<UnityEngine.UI.Text>();
        myTextTQ.color = Color.clear;

        Debug.Log("ScriptStart");

    }

    // Update is called once per frame
    void OnMouseOver()
    {
        //myString.SetActive(true);
        //If your mouse hovers over the GameObject with the script attached, output this message
        Debug.Log("Mouse is over GameObject.");
        myTextTQ.color = Color.black;

    }

    void OnMouseExit()
    {
        //myString.SetActive(false);
        //The mouse is no longer hovering over the GameObject so output this message each frame
        Debug.Log("Mouse is no longer on GameObject.");
        myTextTQ.color = Color.clear;

    }
}
