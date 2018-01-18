using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class difficulty : MonoBehaviour {
    AI ai;
	// Use this for initialization
	void Start () {
        AI ai = new AI();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void easy ()
    {
        ai.difficulty = 0.4f;
    }

    public void normal()
    {
        ai.difficulty = 0.6f;
    }

    public void hard()
    {
        ai.difficulty = 1f;
    }

}
