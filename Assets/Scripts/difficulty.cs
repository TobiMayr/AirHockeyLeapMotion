using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Difficulty : MonoBehaviour
{
    public static readonly Difficulty Easy = new Difficulty(0.4f);
    public static readonly Difficulty Medium = new Difficulty(0.6f);
    public static readonly Difficulty Hard = new Difficulty(1.0f);

    private float difficultyValue;
    private Button easyButton, mediumButton, hardButton;
    Color red = new Color(1, 0, 0, 1);
    Color white = new Color(1, 1, 1, 1);

    // Use this for initialization
    void Start()
    {
        easyButton = GameObject.FindGameObjectWithTag("Easy").GetComponent<Button>();
        mediumButton = GameObject.FindGameObjectWithTag("Medium").GetComponent<Button>();
        hardButton = GameObject.FindGameObjectWithTag("Hard").GetComponent<Button>();
        if (GetDifficulty() == Easy.difficultyValue)
        {
            EasyButtons();
        }
        else if (GetDifficulty() == Medium.difficultyValue)
        {
            MediumButtons();
        }
        else if (GetDifficulty() == Hard.difficultyValue)
        {
            HardButtons();
        }
    }

    public Difficulty(float difficultyValue)
    {
        this.difficultyValue = difficultyValue;
    }

    public void SetEasy()
    {
        PlayerPrefs.SetFloat("Difficulty", Easy.difficultyValue);
        EasyButtons();
    }

    public void SetMedium()
    {
        PlayerPrefs.SetFloat("Difficulty", Medium.difficultyValue);
        MediumButtons();
    }

    public void SetHard()
    {
        PlayerPrefs.SetFloat("Difficulty", Hard.difficultyValue);
        HardButtons();
    }

    public void SetDifficulty()
    {
        PlayerPrefs.SetFloat("Difficulty", difficultyValue);
    }

    public float GetDifficulty()
    {
        return PlayerPrefs.GetFloat("Difficulty");
    }

    private void SetColour(Button button, Color colour)
    {
        ColorBlock cb = button.colors;
        cb.normalColor = colour;
        button.colors = cb;
    }

    private void EasyButtons()
    {
        SetColour(easyButton, red);
        SetColour(mediumButton, white);
        SetColour(hardButton, white);
    }

    private void MediumButtons()
    {
        SetColour(easyButton, white);
        SetColour(mediumButton, red);
        SetColour(hardButton, white);
    }

    private void HardButtons()
    {
        SetColour(easyButton, white);
        SetColour(mediumButton, white);
        SetColour(hardButton, red);
    }
}
