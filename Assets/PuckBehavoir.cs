using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuckBehavoir : MonoBehaviour
{

    GameManager gm;
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
        gm = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameManager>();
        puck = GameObject.FindGameObjectWithTag("Puck").GetComponent<Rigidbody>();
        bandeS = GameObject.FindGameObjectWithTag("side");
        myTransform = transform;
        lastpos = myTransform.position;
        ismoving = false;
    }




    void Update()
    {
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
            RaycastHit hit;
            Ray ray = new Ray(puck.position, puck.velocity);
            if (Physics.Raycast(ray, out hit))
            {

                Vector3 reflectVec = Vector3.Reflect(puck.velocity, hit.normal);
                puck.AddForce(reflectVec.x / 10, 0, reflectVec.z / 10, ForceMode.Acceleration);


            }
        }
            if (c.gameObject.tag == "Wall_R")
            {
                RaycastHit hit2;
                Ray ray2 = new Ray(puck.position, puck.velocity);
                if (Physics.Raycast(ray2, out hit2))
                {

                    Vector3 reflectVec = Vector3.Reflect(puck.velocity, hit2.normal);
                    puck.AddForce(reflectVec.x / 10, 0, reflectVec.z / 10, ForceMode.Acceleration);


                }
            }
            if (c.gameObject.tag == "Wall_L")
            {
                RaycastHit hit3;
                Ray ray3 = new Ray(puck.position, puck.velocity);
                if (Physics.Raycast(ray3, out hit3))
                {

                    Vector3 reflectVec = Vector3.Reflect(puck.velocity, hit3.normal);
                    puck.AddForce(reflectVec.x / 10, 0, reflectVec.z / 10, ForceMode.Acceleration);


                }
            }

        }

}
        
