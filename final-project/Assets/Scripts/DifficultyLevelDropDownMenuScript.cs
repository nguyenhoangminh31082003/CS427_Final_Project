using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class DifficultyLevelDropDownMenuScript : MonoBehaviour
{
    [SerializeField] private Dropdown difficultyDropdown;  // Reference to the Dropdown

    // Key used to store and retrieve the selected difficulty level
    private const string DifficultyPrefKey = "DifficultyLevel";
    private const string InitialMinutesPrefKey = "InitialMinutes";

    void Start()
    {
        // Load the saved difficulty level when the game starts
        this.LoadDifficulty();

        // Add a listener to detect dropdown value changes
        difficultyDropdown.onValueChanged.AddListener(delegate {
            SaveDifficulty(difficultyDropdown.value);
        });
    }

    // Save the selected difficulty level to PlayerPrefs
    void SaveDifficulty(int difficultyValue)
    {
        PlayerPrefs.SetInt(DifficultyPrefKey, difficultyValue);
     
        if (difficultyValue == 0)
            PlayerPrefs.SetInt(InitialMinutesPrefKey, 60);
        else if (difficultyValue == 1)
            PlayerPrefs.SetInt(InitialMinutesPrefKey, 30);
        else if (difficultyValue == 2)
            PlayerPrefs.SetInt(InitialMinutesPrefKey, 15);

        PlayerPrefs.Save();
    }

    // Load the saved difficulty level and set the dropdown to the correct option
    void LoadDifficulty()
    {
        if (PlayerPrefs.HasKey(DifficultyPrefKey))
        {
            int savedDifficulty = PlayerPrefs.GetInt(DifficultyPrefKey);
            difficultyDropdown.value = savedDifficulty;
        }
        else
        {
            // If there's no saved preference, you can set it to a default value (e.g., 0)
            difficultyDropdown.value = 1;  // Assuming 0 is the default
            this.SaveDifficulty(difficultyDropdown.value);
        }
    }
}