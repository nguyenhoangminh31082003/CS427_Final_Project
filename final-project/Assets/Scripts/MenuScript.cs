using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuScript : MonoBehaviour
{
    [SerializeField] private GameObject PlayButton;
    [SerializeField] private GameObject QuitButton;
    public void StartGame()
    {
        SceneManager.LoadScene(1);
    }

    void Start()
    {
        
    }

    public void SetPlayButtonBold()
    {
        PlayButton.GetComponent<TMPro.TextMeshProUGUI>().fontStyle = TMPro.FontStyles.Bold | TMPro.FontStyles.Underline;
        PlayButton.GetComponent<TMPro.TextMeshProUGUI>().color = new Color(1, 1, 1, 1);
    }

    public void SetPlayButtonNormal()
    {
        PlayButton.GetComponent<TMPro.TextMeshProUGUI>().fontStyle = TMPro.FontStyles.Normal;
        PlayButton.GetComponent<TMPro.TextMeshProUGUI>().color = new Color(1, 1, 1, 1);
    }

    public void SetQuitButtonBold()
    {
        QuitButton.GetComponent<TMPro.TextMeshProUGUI>().fontStyle = TMPro.FontStyles.Bold | TMPro.FontStyles.Underline;
        QuitButton.GetComponent<TMPro.TextMeshProUGUI>().color = new Color(1, 1, 1, 1);
    }

    public void SetQuitButtonNormal()
    {
        QuitButton.GetComponent<TMPro.TextMeshProUGUI>().fontStyle = TMPro.FontStyles.Normal;
        QuitButton.GetComponent<TMPro.TextMeshProUGUI>().color = new Color(1, 1, 1, 1);
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    void Update()
    {
        
    }
}
