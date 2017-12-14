using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {
    public float AIScore;
    public float PlayerScore;
    GameObject puck, player, ai, pS, eS; //pS - playerScore, eS - enemyScore
                                            // Use this for initialization
    void Start () {
        PlayerScore = 0f;
        AIScore = 0f;
        puck = GameObject.FindGameObjectWithTag("Puck");
        player = GameObject.FindGameObjectWithTag("Player");
        ai = GameObject.Find("AI");
        pS = GameObject.Find("PlayerScore");
        eS = GameObject.Find("AIScore");
    }
	
	// Update is called once per frame
	void Update () {
        pS.gameObject.GetComponent<TextMesh>().text = "YOU:" + PlayerScore;
        eS.gameObject.GetComponent<TextMesh>().text = "OPP:" + AIScore;
    }

    public void Reset(int status)
    {
        //Reset all the gameObjects to original position to start a new game session
        if (status == 1) //recieved when striker hits any goal, check Striker.cs
            puck.transform.position = new Vector3(0.06f, puck.transform.position.y, 2.82f);//if  enemy wins, 
                                                                                           //place on player side
        else if (status == 0)
            puck.transform.position = new Vector3(0.06f, puck.transform.position.y, -4.59f);

        
            

        puck.gameObject.GetComponent<Rigidbody>().velocity = new Vector3(0f, 0f, 0f);//stop the striker
        player.transform.position = new Vector3(0.88f, player.transform.position.y, -8.17f);
        ai.transform.position = new Vector3(0.88f, ai.transform.position.y, 6.65f);
    }

   

}


