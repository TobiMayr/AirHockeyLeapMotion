using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sound_powerupwall : MonoBehaviour {

    public AudioSource wall;    // Add your Audi Clip Here;
                                // This Will Configure the  AudioSource Component; 
                                // MAke Sure You added AudioSouce to death Zone;
    void Start()
    {
        wall = GameObject.FindGameObjectWithTag("powerupwallsound").GetComponent<AudioSource>();

    }

    void OnCollisionEnter(Collision c)  //Plays Sound Whenever collision detected
    {
        if (c.gameObject.tag == "Puck")
        {
            wall.Play();
        }
       
    }
}
