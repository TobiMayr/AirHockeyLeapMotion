using UnityEngine;
using UnityEngine.UI;

public class LevelManager : MonoBehaviour
{
    private static LevelManager instance;
    public static LevelManager Instance { get { return instance; } }
    public Text timerText;
    private float startTime;
    private float levelDuration;

    // Use this for initialization
    void Start()
    {
        instance = this;
        startTime = Time.time;
    }

    // Update is called once per frame
    void Update()
    {
        switch (GameManager.selectedMode)
        {
            case GameManager.GameMode.Match:
                break;
            case GameManager.GameMode.Arcade:
                levelDuration = Time.time - startTime;
                string minutes = ((int)levelDuration / 60).ToString("00");
                string seconds = (levelDuration % 60).ToString("00.00");
                timerText.text = minutes + ":" + seconds;
                break;
        }
    }
}