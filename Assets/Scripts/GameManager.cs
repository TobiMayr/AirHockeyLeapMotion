using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;



public class GameManager : MonoBehaviour {
    public float AIScore;
    public float PlayerScore;
    private GameObject clone;
    GameObject puck, player, ai, pS, eS, powerup_w, powerup_b; //pS - playerScore, eS - enemyScore
    private bool isActive = false;                 // Use this for initialization
    public GameObject GameMatchWin,GameMatchLose,GameArcadeWin, GameArcadeLose, PauseMenu;
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
        PlayerScore = 0f;
        AIScore = 0f;
        puck = GameObject.FindGameObjectWithTag("Puck");
        player = GameObject.FindGameObjectWithTag("Player");
        ai = GameObject.Find("AI");
        pS = GameObject.Find("PlayerScore");
        eS = GameObject.Find("AIScore");
       
        GameMatchWin.SetActive(false);
        GameMatchLose.SetActive(false);
        GameArcadeWin.SetActive(false);
        GameArcadeLose.SetActive(false);
        PauseMenu.SetActive(false);


    }
	
	// Update is called once per frame
	void Update () {
        pS.gameObject.GetComponent<TextMesh>().text = "YOU:" + PlayerScore;
        eS.gameObject.GetComponent<TextMesh>().text = "OPP:" + AIScore;
        //endgame menu visible
        if (selectedMode == GameMode.Match)
        {
            if (PlayerScore >= 10)
            {
                Time.timeScale = 0;
                GameMatchWin.SetActive(true);

            }
            else if(AIScore >=10)
            {
                Time.timeScale = 0;
                GameMatchLose.SetActive(true);
            }
        }
      /*  if (selectedMode == GameMode.Arcade)
        {
            if(lm.levelDuration < 0)
            {
                if(PlayerScore >= AIScore)
                {
                    Time.timeScale = 0;
                    GameArcadeWin.SetActive(true);
                }
                else if(AIScore >= PlayerScore)
                {
                    Time.timeScale = 0;
                    GameArcadeLose.SetActive(true);
                }

            }
            
        }*/

        //PauseMenu visible
        if (Time.timeScale == 1)
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                Time.timeScale = 0;
                //isActive = true;
                PauseMenu.SetActive(true);
            }
        }

        else if (Time.timeScale == 0)
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                //isActive = false;
                Time.timeScale = 1;
                PauseMenu.SetActive(false);
            }
        }
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

    public void Restart()
    {
        Time.timeScale = 1;
        GameMatchWin.SetActive(false);
        GameMatchLose.SetActive(false);
        GameArcadeWin.SetActive(false);
        GameArcadeLose.SetActive(false);
        PauseMenu.SetActive(false);
        puck.gameObject.GetComponent<Rigidbody>().velocity = new Vector3(0f, 0f, 0f);//stop the striker
        player.transform.position = new Vector3(0.88f, player.transform.position.y, -8.17f);
        ai.transform.position = new Vector3(0.88f, ai.transform.position.y, 6.65f);
        puck.transform.position = new Vector3(0.06f, puck.transform.position.y, -2.59f);
       
        PlayerScore = 0;
        AIScore = 0;
        GameObject[] all = GameObject.FindGameObjectsWithTag("powerup_b");
           foreach (GameObject g in all)
            Destroy(g);

        GameObject[] all2 = GameObject.FindGameObjectsWithTag("powerup_w");
        foreach (GameObject v in all2)
            Destroy(v);

        GameObject[] all3 = GameObject.FindGameObjectsWithTag("Wall_R");
        foreach (GameObject b in all3)
            Destroy(b);

        GameObject[] all4 = GameObject.FindGameObjectsWithTag("Wall_L");
        foreach (GameObject h in all4)
            Destroy(h);
    }

    public void LoadMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void Resume()
    {
        Time.timeScale = 1;
        PauseMenu.SetActive(false);
    }

}


