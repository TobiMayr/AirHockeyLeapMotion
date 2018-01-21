using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuckBehavoir : MonoBehaviour
{

    LevelManager lm;
    Vector3 lastpos;
    Transform myTransform;
    bool ismoving;
    GameObject bandeS;
    bool stopped = false;
    Rigidbody puck;
    float stoppedTime;

    private Vector3 oldVelocity;
    void Awake()
    {

    }

    // Use this for initialization
    void Start()
    {
        lm = GameObject.FindGameObjectWithTag("LevelController").GetComponent<LevelManager>();
        puck = GameObject.FindGameObjectWithTag("Puck").GetComponent<Rigidbody>();
        bandeS = GameObject.FindGameObjectWithTag("side");
        myTransform = transform;
        lastpos = myTransform.position;
        ismoving = false;
    }




    void Update()
    {
        if (puck.position.x <= -4.7f || puck.position.x >= 4.9f || puck.position.z >= 6.1f  || puck.position.z <= -8.9f)
        {
            Vector3 dir = puck.position - new Vector3 (0.38f, 0, -1.13f);
            dir = dir.normalized;
            puck.AddForce(dir * 2.0f, ForceMode.Impulse);
        }

        // because we want the velocity after physics, we put this in fixed update
        /*if (puck.position.x != lastpos.x)
        {
            ismoving = true;
            stopped = false;
        }
        else
            ismoving = false;
         while(ismoving == false)
         {
            if(!stopped)
            {
                stopped = true;
                stoppedTime = Time.time;
            }
            if(Time.time - stoppedTime > 3f)
            {
                puck.AddForce(8, 0, 8, ForceMode.Impulse);
            }

         }
        lastpos = myTransform.position;*/


    }



    void OnTriggerEnter(Collider c)
    {


        if (c.tag == "Goal_Player")
        {
            lm.AIScore += 1f;
            lm.Reset(1);
        }
        if (c.tag == "Goal_AI")
        {
            lm.PlayerScore += 1f;
            lm.Reset(0);
        }




    }
    //der versuch des aprallens an der wand
   /* void OnCollisionEnter(Collision c)
    {
        if (c.gameObject.tag == "side" || c.gameObject.tag == "Wall_R" || c.gameObject.tag == "Wall_L" || c.gameObject.tag == "front")
        {
            RaycastHit hit;
            Ray ray = new Ray(puck.position, puck.velocity);
            if (Physics.Raycast(ray, out hit))
            {

                Vector3 reflectVec = Vector3.Reflect(puck.velocity, hit.normal);
                puck.AddForce(reflectVec.x / 10, 0, reflectVec.z / 10);
            }
        }
    }*/
}

