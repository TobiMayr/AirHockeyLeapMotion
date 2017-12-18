using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Puck_sound : MonoBehaviour {

    public AudioSource puck;    // Add your Audi Clip Here;
                             // This Will Configure the  AudioSource Component; 
                             // MAke Sure You added AudioSouce to death Zone;
    void Start()
    {
        puck = GameObject.FindGameObjectWithTag("puck_sound").GetComponent<AudioSource>();

    }

    void OnCollisionEnter(Collision c)  //Plays Sound Whenever collision detected
    {
        if (c.gameObject.tag == "Player")
        {
            puck.Play();
        }
        else if(c.gameObject.tag== "AI")
        {
            puck.Play();
        }
    }
    // Make sure that deathzone has a collider, box, or mesh.. ect..,
    // Make sure to turn "off" collider trigger for your deathzone Area;
    // Make sure That anything that collides into deathzone, is rigidbody;
}
