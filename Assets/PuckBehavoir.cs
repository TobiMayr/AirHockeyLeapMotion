using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuckBehavoir : MonoBehaviour
{
    
    GameManager gm;
   
   
    Rigidbody puck;
    
    private Vector3 oldVelocity;
    void Awake()
    {

    }

    // Use this for initialization
    void Start()
    {
        gm = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameManager>();
        puck = GameObject.FindGameObjectWithTag("Puck").GetComponent<Rigidbody>();
    }
   


  
    void Update()
    {
        // because we want the velocity after physics, we put this in fixed update
        oldVelocity = puck.velocity;
    }
    void OnTriggerEnter(Collider c)
    {
        if (c.tag == "Goal_Player")
        {
            gm.AIScore += 1f;
            gm.Reset(1);
        }
        if (c.tag == "Goal_AI")
        {
            gm.PlayerScore += 1f;
            gm.Reset(0);
        }

    }
    //der versuch des aprallens an der wand
    void OnCollisionEnter(Collision c)
    {
        if (c.gameObject.tag == "side")
        {
            
            ContactPoint contact = c.contacts[0];// = punkte wo die collision statt findet mit dem puck rigidbody

            // reflect our old velocity off the contact point's normal vector
            Vector3 reflectedVelocity = Vector3.Reflect(oldVelocity, contact.normal);

            // assign the reflected velocity back to the rigidbody
            puck.velocity += contact.normal ;
            // rotate the object by the same ammount we changed its velocity
            Quaternion rotation = Quaternion.FromToRotation(oldVelocity, reflectedVelocity);
            transform.rotation = rotation * transform.rotation;
        }
        else if (c.gameObject.tag=="front")
        {
            ContactPoint contact = c.contacts[0];
            Vector3 reflectedVelocity = Vector3.Reflect(oldVelocity, contact.normal);
            puck.velocity += contact.normal;
            Quaternion rotation = Quaternion.FromToRotation(oldVelocity, reflectedVelocity);
            transform.rotation = rotation * transform.rotation;
        }
    }
    
}

        
