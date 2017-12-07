using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawner_powerups : MonoBehaviour {

    public GameObject[] powerups;
    public Vector3 spawnValues;
    public float spawnWait;
    public float spawnMostWait = 20;
    public float spawnLeastWait = 5;
    public int startWait=30;
    public bool stop;

    int randomPowerUp;


	// Use this for initialization
	void Start () {
        StartCoroutine(waitSpawner());
	}
	
	// Update is called once per frame
	void Update () {
        spawnWait = Random.Range(spawnLeastWait, spawnMostWait);
	}

    IEnumerator waitSpawner()
    {
        yield return new WaitForSeconds(startWait);

        while (!stop)
        {
            randomPowerUp = Random.Range(0, 2);
            //3 powerups. 0,1,2
            
            Vector3 spawnPosition = new Vector3(Random.Range(-spawnValues.x, spawnValues.x), 1,Random.Range(-spawnValues.z, spawnValues.z));
            Instantiate (powerups[randomPowerUp], spawnPosition + transform.TransformPoint (-8,-7,7), gameObject.transform.rotation);
            yield return new WaitForSeconds(spawnWait);
        }
    }
}
