using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Leap.Unity;
using Leap;

public class PlayerControl : MonoBehaviour
{
    
   BoxCollider coll;
    Rigidbody puckr;
    GameObject player;
    Rigidbody playerr;
    GameObject pu;
    public float playerSpeed; //selbt setzten
    public float PuckSpeed;// puck geschwindigkeit
    
    GameObject controller;
    public IHandModel handmodel;
    //AI ai;
    
    
   /* void Awake()
    {
        PuckSpeed = PuckSpeed + 30.0f;
    }*/

    // Use this for initialization
    void Start()
    {
        // ai = GameObject.Find("AI").GetComponent<AI>();
        coll = GameObject.Find("Table").GetComponent<BoxCollider>();
        puckr = GameObject.FindGameObjectWithTag("Puck").GetComponent<Rigidbody>();
        player = GameObject.Find("Player");

        pu = GameObject.FindGameObjectWithTag("Puck");
        playerr = GameObject.FindGameObjectWithTag("Player").GetComponent<Rigidbody>();
       
        controller = GameObject.Find("LeapHandController");
        
    }

    // bewegung mit der maus
    Plane movePlane;
    float fixedDistance = -2.12f;
    float hitDist, t;
    Ray camRay;
    Vector3 startPos, point, corPoint;
    private float collisionAngle;

    void OnMouseDown()
    {
        startPos = transform.position; // save position in case draged to invalid place
        movePlane = new Plane(-Camera.main.transform.forward, transform.position); // find a parallel plane to the camera based on obj start pos;
    }

    void OnMouseDrag()
    {
        camRay = Camera.main.ScreenPointToRay(Input.mousePosition); // shoot a ray at the obj from mouse screen point

        if (movePlane.Raycast(camRay, out hitDist))
        { // finde the collision on movePlane
            point = camRay.GetPoint(hitDist); // define the point on movePlane
            t = -(fixedDistance - camRay.origin.y) / (camRay.origin.y - point.y); // the x,y or z plane you want to be fixed to
            corPoint.x = camRay.origin.x + (point.x - camRay.origin.x) * t; // calculate the new point t futher along the ray
            corPoint.y = camRay.origin.y + (point.y - camRay.origin.y) * t;
            corPoint.z = camRay.origin.z + (point.z - camRay.origin.z) * t;
            transform.position = corPoint;
        }
    }

    // Update is called once per frame
    void Update()
    {
        //bewegung mit leap
        Hand hand = handmodel.GetLeapHand();
        if (hand != null)
        {
            transform.position = hand.PalmPosition.ToVector3();
            player.transform.position = new Vector3(hand.PalmPosition.x, player.transform.position.y, hand.PalmPosition.z); 

        }


            //Bewegung mit den tasten

            /*
            if (Input.GetKey("left"))
                transform.Translate(-playerSpeed * Time.deltaTime, 0f, 0f);
            if (Input.GetKey("right"))
                transform.Translate(playerSpeed * Time.deltaTime, 0f, 0f);
            if (Input.GetKey("up"))
                transform.Translate(0f, 0f, playerSpeed * Time.deltaTime);
            if (Input.GetKey("down"))
                transform.Translate(0f, 0f, -playerSpeed * Time.deltaTime);*/


            //bewegung einschränken des players
            if (transform.position.x <= -4.2f)
             transform.position = new Vector3(-4.2f, transform.position.y, transform.position.z);
         if (transform.position.x >= 4.4f)
             transform.position = new Vector3(4.4f, transform.position.y, transform.position.z);
         if (transform.position.z >= 5.45f)
             transform.position = new Vector3(transform.position.x, transform.position.y, 5.45f);
         if (transform.position.z <= -8.4f)
             transform.position = new Vector3(transform.position.x, transform.position.y, -8.4f);

         //sollte dafür sorgen das wenn playersehr schnell bewegt wird trotzdem die collision statt findet 
         // scheint nihct zu fnktionieren kp ob es an der falschen stelle ist oder sonst was xD
       /* puck.collisionDetectionMode = CollisionDetectionMode.ContinuousDynamic;
        player.collisionDetectionMode = CollisionDetectionMode.ContinuousDynamic;*/
    }
    
    // hier der code für die collision mit dem puck es muss die velocity vom player auf den puck übetragen werden
    void OnCollisionEnter(Collision c)
    {
        
        if (c.gameObject.tag == "Puck")
        {
           // puck.velocity = c.;
            puckr.AddForce(c.relativeVelocity.x/10, 0, c.relativeVelocity.z/10, ForceMode.Impulse);
        }
        // code mit pfeil tasten
            /*if (c.gameObject.tag == "Puck")
            {
                // ai.counter = 0f; //warum steht im AI code

                //steuerung des pucks beim auftrefen

                if (Input.GetKey("up"))
                {
                    puck.velocity = new Vector3(0.00f, puck.velocity.y, PuckSpeed);

                    if (Input.GetKey("right"))
                    {
                        //puck.velocity = new Vector3(PuckSpeed, 0, PuckSpeed);
                        puck.velocity = new Vector3(PuckSpeed, puck.velocity.y, PuckSpeed);
                    }
                    else if (Input.GetKey("left"))
                    {
                        //puck.velocity = new Vector3(-PuckSpeed, 0, PuckSpeed);
                        puck.velocity = new Vector3(-PuckSpeed, puck.velocity.y, PuckSpeed);
                    }

                }
                else if (Input.GetKey("down"))
                {
                    puck.velocity = new Vector3(0.00f, puck.velocity.y, -PuckSpeed);

                    if (Input.GetKey("right"))
                    {
                        //puck.velocity = new Vector3(PuckSpeed, 0, PuckSpeed);
                        puck.velocity = new Vector3(PuckSpeed, puck.velocity.y, -PuckSpeed);
                    }
                    else if (Input.GetKey("left"))
                    {
                        //puck.velocity = new Vector3(-PuckSpeed, 0, PuckSpeed);
                        puck.velocity = new Vector3(-PuckSpeed, puck.velocity.y, -PuckSpeed);
                    }

                }
                else if (Input.GetKey("right"))
                {
                    puck.velocity = new Vector3(PuckSpeed, puck.velocity.y, 0.00f);
                }
                else if (Input.GetKey("left"))
                {
                    puck.velocity = new Vector3(-PuckSpeed, puck.velocity.y, 0.00f);
                }

            }*/
        }


            
}

           

    




