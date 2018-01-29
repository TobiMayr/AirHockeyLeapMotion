using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnMouseHoverTM : MonoBehaviour {

    public string myString;
  
    public UnityEngine.UI.Text myTextTM;
    
    public bool displayInfo;
    // Use this for initialization
    void Start()
    {
       
        myTextTM = GameObject.Find("Hover_text_TM").GetComponent<UnityEngine.UI.Text>();
        myTextTM.color = Color.clear;
       
        Debug.Log("ScriptStart");

    }

    // Update is called once per frame
    void OnMouseOver()
    {
        //myString.SetActive(true);
        //If your mouse hovers over the GameObject with the script attached, output this message
        Debug.Log("Mouse is over GameObject.");
       
        myTextTM.color = Color.black;
       
    }

    void OnMouseExit()
    {
        //myString.SetActive(false);
        //The mouse is no longer hovering over the GameObject so output this message each frame
        Debug.Log("Mouse is no longer on GameObject.");
        
        myTextTM.color = Color.clear;
       
    }
}

