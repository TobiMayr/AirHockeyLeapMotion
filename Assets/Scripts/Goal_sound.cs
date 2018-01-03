using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Goal_sound : MonoBehaviour {

    public AudioSource goal;    // Add your Audi Clip Here;
                                // This Will Configure the  AudioSource Component; 
                                // MAke Sure You added AudioSouce to death Zone;
    void Start()
    {
        goal = GameObject.FindGameObjectWithTag("goal_sound").GetComponent<AudioSource>();

    }

    void OnTriggerEnter(Collider c)  //Plays Sound Whenever collision detected
    {
        if (c.tag == "Puck")
        {
            goal.Play();
        }
        else if (c.tag == "Puck")
        {
            goal.Play();
        }
    }
    // Make sure that deathzone has a collider, box, or mesh.. ect..,
    // Make sure to turn "off" collider trigger for your deathzone Area;
    // Make sure That anything that collides into deathzone, is rigidbody;
}
