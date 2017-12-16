using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanvasManager : MonoBehaviour {

	//public ArrayList allCanvases;
	public GameObject InitialCanvas;
	public List <GameObject> allCanvases;

	public void setActiveCanvas(GameObject Canvas)
	{
		foreach(GameObject index in allCanvases)
		{
			index.SetActive (false);
		}
	
		Canvas.SetActive (true);
	}

	// Use this for initialization
	void Start () {
		setActiveCanvas (InitialCanvas);
	}

	// Update is called once per frame
	void Update () {
		
	}
}
