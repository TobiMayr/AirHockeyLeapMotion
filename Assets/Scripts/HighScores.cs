using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HighScores : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void LoadHighScores()
    {
        string highscoresSerialized = PlayerPrefs.GetString("highscores", "");
        Dictionary<string, int> highscores = MyUnserialize(highscoresSerialized);

        // Update highscores.
        highscores["Xavier"] = 100;

        // Show highscores.
        foreach (var entry in highscores)
        {
            print(entry.Key + ": " + entry.Value);
        }

    }

    private Dictionary<string, int>  MyUnserialize(string stringy)
    {
        return new Dictionary<string, int>();
    }
}
