using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InvisibleBox : MonoBehaviour {
    Rigidbody puck;
    // Use this for initialization
    void Start () {
        puck = GameObject.FindGameObjectWithTag("Puck").GetComponent<Rigidbody>();
    }
	
	// Update is called once per frame
	void Update () {
		
	}
    void OnCollisionEnter(Collision c)
    {
        if (c.gameObject.tag == "Puck")
        {
            puck.transform.position = new Vector3(0.06f, puck.transform.position.y, 1.00f);
        }
    }
}
