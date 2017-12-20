using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class powerupwall : MonoBehaviour
{

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    void OnCollisionEnter(Collision c)
    {

        if (c.gameObject.tag == "Puck")
        {
            Destroy(this.gameObject);
        }
    }
}

