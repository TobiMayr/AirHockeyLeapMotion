using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class power_up_goal : MonoBehaviour {
    Rigidbody puck;
   public GameObject Wall_L;
    public GameObject Wall_R;
    private float wait = 5f;
    private bool wall_act = false;
	// Use this for initialization
	void Start () {
        puck = GameObject.FindGameObjectWithTag("Puck").GetComponent<Rigidbody>();
       
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    

        void OnTriggerEnter(Collider c)
    {
        
        if (c.tag == "Puck")
        {
            Debug.Log("blaues powerup");
            Destroy(this.gameObject);
            puck.velocity = puck.velocity;
            Instantiate(Wall_R, Wall_R.transform.position, Wall_R.transform.rotation);
            Instantiate(Wall_L, Wall_L.transform.position, Wall_L.transform.rotation);


        }

    }
    
}
