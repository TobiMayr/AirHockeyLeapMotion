using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnMouseHoverMSAA : MonoBehaviour {

    public string myString;
    
    public UnityEngine.UI.Text myTextMSAA;
    
    public bool displayInfo;
    // Use this for initialization
    void Start()
    {
      
        myTextMSAA = GameObject.Find("Hover_text_MSAA").GetComponent<UnityEngine.UI.Text>();
        myTextMSAA.color = Color.clear;
       
        Debug.Log("ScriptStart");

    }

    // Update is called once per frame
    void OnMouseOver()
    {
        //myString.SetActive(true);
        //If your mouse hovers over the GameObject with the script attached, output this message
        Debug.Log("Mouse is over GameObject.");

        myTextMSAA.color = Color.black;
    }

    void OnMouseExit()
    {
        //myString.SetActive(false);
        //The mouse is no longer hovering over the GameObject so output this message each frame
        Debug.Log("Mouse is no longer on GameObject.");
       
        myTextMSAA.color = Color.clear;
      
    }
}


