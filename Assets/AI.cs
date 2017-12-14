using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AI : MonoBehaviour {
    
    GameObject Puck;
    Rigidbody puckRB;
    float forceDir;
    public float counter;
    public float PuckSpeed;
    Vector3 basePoint;
    public float difficulty;
    float smashCance;

    void Awake()
    {
        difficulty = PlayerPrefs.GetFloat("Difficulty");
    }

    // Use this for initialization
    void Start () {
        Puck = GameObject.FindGameObjectWithTag("Puck");
        puckRB = GameObject.FindGameObjectWithTag("Puck").GetComponent<Rigidbody>();

        //schwiereigkeitsetzten
        //
        // je höher die schwierigkeit die desto defensiver und mehr zeit zum denken hat die Ai
        //wenn die schwierigkeit = 1 ist ist die Ai nicht zu besiegen 

        if (difficulty < 0.45f)
        { //easy
            basePoint = new Vector3(0.88f, transform.position.y, 0.85f);
            difficulty = 0.2f;
        }
        else if (difficulty >= 0.45f && difficulty < 1f)
        {
            basePoint = new Vector3(0.88f, transform.position.y, 3.3f);
            difficulty = 0.7f;
        }
        else if (difficulty == 1f)
        {
            basePoint = new Vector3(0.88f, transform.position.y, 6.65f);
        }

    }


	
	// Update is called once per frame
	void Update () {
    counter += 1f * Time.deltaTime; //acts like a timer

        if (Puck.transform.position.z >= -0.2f)
        { //if striker is in its half
            if (counter >= 1f)
            { //wait for one second to see if the stiker comes to you or stops, if it does not come then :
                Vector3 newPos = new Vector3(Puck.transform.position.x - 0.5f, Puck.transform.position.y, Puck.transform.position.z + 0.5f);
                //move towards the striker to its position
                transform.position = Vector3.MoveTowards(transform.position, newPos, 4f * Time.deltaTime);
                //4f * Time.deltaTime states time to transit the two positions

            }
            else //if less than 1 second change your x-position based on difficulty, i.e. try to move closer to striker
                transform.position = new Vector3(Puck.transform.position.x * difficulty, transform.position.y, transform.position.z);
        }
        else //if in other half then move towards base position
            transform.position = Vector3.MoveTowards(transform.position, basePoint, 2f * Time.deltaTime);



    }
    void OnCollisionEnter(Collision c)
    {
        if (c.gameObject.tag == "Puck")
        {
            counter = 0f; //on hitting reset the wait time...
            forceDir = (int)Random.Range(0, 10);//for hitting to the left or right
            smashCance = 100; //chance that it will smash the striker
                                                   //hit the striker with force
            if (forceDir <= 5)
                puckRB.AddForce(puckRB.velocity.x/10, 0, puckRB.velocity.z/10, ForceMode.Impulse);
            else
                puckRB.AddForce(puckRB.velocity.x/10, 0, puckRB.velocity.z/10 , ForceMode.Impulse);

        }
    }

}

