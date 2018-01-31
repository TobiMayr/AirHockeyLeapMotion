using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class HighScores : MonoBehaviour
{

    public GameObject scoreContainer;
    public GameObject oldScorePrefab;
    public GameObject newScorePrefab;
    public Button deleteScoreButton;
    private string highscoresSerialized;
    private Dictionary<string, int> highscores;

    // Use this for initialization
    void Start()
    {
        highscoresSerialized = PlayerPrefs.GetString("highscores", "");
        var input = newScorePrefab.transform.GetChild(0).GetComponent<InputField>();
        var se = new InputField.SubmitEvent();
        se.AddListener(SaveNewHighScore);
        input.onEndEdit = se;
        deleteScoreButton.onClick.AddListener(DeleteScores);
        LoadHighScores();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void DeleteScores()
    {
        PlayerPrefs.SetString("highscores", "");
        LoadHighScores();
    }

    private void SaveNewHighScore(string arg0)
    {
        int points = Int32.Parse(newScorePrefab.transform.GetChild(1).GetComponent<Text>().text);
        newScorePrefab.SetActive(false);
        if (highscores.ContainsKey(arg0))
        {
            if (highscores[arg0] < points)
            {
                highscores[arg0] = points;
            }
        }
        else
        {
            highscores.Add(arg0, points);
        }
        highscoresSerialized = SerializeHighScores(highscores);
        PlayerPrefs.SetString("highscores", highscoresSerialized);

        LoadHighScores();
    }

    private void LoadHighScores()
    {
        highscoresSerialized = PlayerPrefs.GetString("highscores", "");
        highscores = UnserializeHighScores(highscoresSerialized);

        //nehme nur die Top 10
        highscores = highscores.OrderByDescending(pair => pair.Value).Take(10)
               .ToDictionary(pair => pair.Key, pair => pair.Value);

        foreach (Transform child in scoreContainer.transform)
        {
            if (child.name != "NewScorePrefab")
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

    private Dictionary<string, int> UnserializeHighScores(string wholeString)
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
        return finalString;
    }
}
