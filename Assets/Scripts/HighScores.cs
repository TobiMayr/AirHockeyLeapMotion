using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class HighScores : MonoBehaviour {

    public GameObject scoreContainer;
    public GameObject oldScorePrefab;
    public GameObject newScorePrefab;
    private bool isNewHighScore = true;
    private string highscoresSerialized;

    // Use this for initialization
    void Start () {
        //PlayerPrefs.SetString("highscores", "lala" + "|" + "55" + "\\" + "hihi" + "|" + "5445" + "\\" + "hoho" + "|" + "51235" + "\\" + "ssss" + "|" + "515" + "\\" + "fffff" + "|" + "1" + "\\" + "eeeeee" + "|" + "2" + "\\");
        highscoresSerialized = PlayerPrefs.GetString("highscores", "");
        var input = newScorePrefab.transform.GetChild(0).GetComponent<InputField>();
        var se = new InputField.SubmitEvent();
        se.AddListener(SaveNewHighScore);
        input.onEndEdit = se;
        LoadHighScores();
    }
	
	// Update is called once per frame
	void Update () {
        
    }

    private void SaveNewHighScore(string arg0)
    {
        string points = newScorePrefab.transform.GetChild(1).GetComponent<Text>().text;
        if (isNewHighScore)
        {
            newScorePrefab.SetActive(false);
            PlayerPrefs.SetString("highscores", highscoresSerialized + arg0 + "|" + points + "\\");
        }
        LoadHighScores();
    }

    private void LoadHighScores()
    {
        highscoresSerialized = PlayerPrefs.GetString("highscores", "");
        Dictionary<string, int> highscores = UnserializeHighScores(highscoresSerialized);

        //nehme nur die Top 10
        highscores = highscores.OrderByDescending(pair => pair.Value).Take(10)
               .ToDictionary(pair => pair.Key, pair => pair.Value);

        foreach (Transform child in scoreContainer.transform)
        {
            if(child.name != "NewScorePrefab")
            {
                Destroy(child.gameObject);
            }
        }
        // Update highscores.
        //highscores["Xavier"] = 100;

        // Show highscores.
        foreach (var entry in highscores)
        {
            GameObject container = Instantiate(oldScorePrefab) as GameObject;
            container.transform.GetChild(0).GetComponent<Text>().text = entry.Key;
            container.transform.GetChild(1).GetComponent<Text>().text = entry.Value.ToString();
            container.transform.SetParent(scoreContainer.transform, false);
        }

    }

    private Dictionary<string, int>  UnserializeHighScores(string wholeString)
    {
        Dictionary<string, int> dict = new Dictionary<string, int>();
        var strings = wholeString.Split('\\');
        foreach (string entry in strings)
        {
            string[] pair = entry.Split('|');
            if (pair.Length <= 1) continue;
            dict.Add(pair[0], Int32.Parse(pair[1]));
        }
        return dict;
    }

    private string SerializeHighScores(Dictionary<string, int> dict)
    {
        string finalString = "";

        foreach (var entry in dict)
        {
            finalString += entry.Key.ToString() + "|" + entry.Value.ToString() + "\\";
        }
        return "";
    }
}
