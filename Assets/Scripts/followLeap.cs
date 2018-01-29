using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class followLeap : MonoBehaviour {
    public GameObject target;
    GameObject hand;
    Vector3 vec;
	// Use this for initialization
	void Start () {
		hand = this.gameObject;
        vec = new Vector3(hand.transform.position.x, target.transform.position.y, hand.transform.position.z);
	}
	
	// Update is called once per frame
	void Update () {
        target.transform.position = vec;
	}
}
