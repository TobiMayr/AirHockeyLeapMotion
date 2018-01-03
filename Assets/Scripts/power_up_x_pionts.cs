using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class power_up_x_pionts : MonoBehaviour
{

    Rigidbody puck;
    Rigidbody AI;
    GameManager gm;


    // Use this for initialization
    void Start()
    {
        puck = GameObject.FindGameObjectWithTag("Puck").GetComponent<Rigidbody>();
        AI = GameObject.FindGameObjectWithTag("AI").GetComponent<Rigidbody>();
        gm = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnTriggerEnter(Collider c)
    {
        if (c.tag == "Puck")
        {
            Destroy(this.gameObject);
            puck.velocity = puck.velocity;
            gm.PlayerScore += 2f;







        }
    }


}
