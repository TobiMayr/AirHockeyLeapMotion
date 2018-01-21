using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;



public class GameManager : MonoBehaviour {

    private GameObject clone;

    private bool isActive = false;                 // Use this for initialization

    public enum GameMode { Match, Arcade};
    public static GameMode selectedMode;
    private static GameManager instance;
    public static GameManager Instance { get { return instance; } }
    private LevelManager lm;

    void Awake()
    {
        instance = this;
        DontDestroyOnLoad(gameObject);
    }

    void Start () {



    }
	
	// Update is called once per frame
	void Update () {
        
    }

}


