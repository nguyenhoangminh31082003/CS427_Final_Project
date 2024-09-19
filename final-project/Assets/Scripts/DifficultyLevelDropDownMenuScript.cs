using TMPro;
using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class DifficultyLevelDropDownMenuScript : MonoBehaviour
{
    [SerializeField] private TMP_Dropdown difficultyDropdown;

    void Start()
    {
        // Load saved difficulty level
        int savedDifficulty = PlayerPrefs.GetInt("DifficultyLevel", 0);
        difficultyDropdown.value = savedDifficulty;

        this.SaveDifficultyLevel(savedDifficulty);

        // Add listener for when the value changes
        difficultyDropdown.onValueChanged.AddListener(delegate {
            SaveDifficultyLevel(difficultyDropdown.value);
        });
    }

    void SaveDifficultyLevel(int difficultyLevel)
    {
        if (difficultyLevel != 0 && difficultyLevel != 1 && difficultyLevel != 2)
            difficultyLevel = 1;

        // Save the selected difficulty level to PlayerPrefs
        PlayerPrefs.SetInt("DifficultyLevel", difficultyLevel);

        if (difficultyLevel == 0) 
        {
            PlayerPrefs.SetInt("InitialMinutes", 60);
            TimerScript.SetInitialGameDuration(60);
        }
        else if (difficultyLevel == 1)
        {
            PlayerPrefs.SetInt("InitialMinutes", 30);
            TimerScript.SetInitialGameDuration(30);
        }
        else if (difficultyLevel == 2)
        {
            PlayerPrefs.SetInt("InitialMinutes", 15);
            TimerScript.SetInitialGameDuration(15);
        }

        PlayerPrefs.Save();
    }
}