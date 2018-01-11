using UnityEngine;
using UnityEngine.UI;

public class LevelManager : MonoBehaviour
{
    private static LevelManager instance;
    public static LevelManager Instance { get { return instance; } }
    public Text timerText;
    private float endTime;
    private float levelDuration;
    private float TimerTime = 180; //3 minutes
    public bool countDownDone = false;

    // Use this for initialization
    void Start()
    {
        instance = this;
        endTime = Time.time + TimerTime;
    }

    // Update is called once per frame
    void Update()
    {
        if (instance.countDownDone == true)
        {
            switch (GameManager.selectedMode)
            {
                case GameManager.GameMode.Match:
                    break;
                case GameManager.GameMode.Arcade:
                    DisplayTimeLeft();
                    break;
            }
        }
        else
        {
            endTime = Time.time + TimerTime;
        }
    }

    private void DisplayTimeLeft()
    {
        levelDuration = endTime - Time.time;
        if (levelDuration < 0)
        {
            GameManager.Instance.GameEndMenu.SetActive(true);
        }
        else
        {
            string minutes = ((int)levelDuration / 60).ToString("00");
            string seconds = (levelDuration % 60).ToString("00.00");
            timerText.text = minutes + ":" + seconds;
        }
    }
}