using UnityEngine;

public class power_up_x_pionts : MonoBehaviour
{

    Rigidbody puck;
    Rigidbody AI;
    LevelManager lm;


    // Use this for initialization
    void Start()
    {
        puck = GameObject.FindGameObjectWithTag("Puck").GetComponent<Rigidbody>();
        AI = GameObject.FindGameObjectWithTag("AI").GetComponent<Rigidbody>();
        lm = GameObject.FindGameObjectWithTag("LevelController").GetComponent<LevelManager>();
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
            lm.PlayerScore += 2f;
        }
    }

}
