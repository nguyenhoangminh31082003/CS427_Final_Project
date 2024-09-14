using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuScript : MonoBehaviour
{
    // Start is called before the first frame update
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
        PlayButton.GetComponent<TMPro.TextMeshProUGUI>().fontStyle = TMPro.FontStyles.Bold;
        //Set color to red with alpha 0.8
        PlayButton.GetComponent<TMPro.TextMeshProUGUI>().color = new Color(1, 0, 0, 0.8f);
    }

    public void SetPlayButtonNormal()
    {
        PlayButton.GetComponent<TMPro.TextMeshProUGUI>().fontStyle = TMPro.FontStyles.Normal;
        PlayButton.GetComponent<TMPro.TextMeshProUGUI>().color = new Color(1, 1, 1, 1);
    }

    public void SetQuitButtonBold()
    {
        QuitButton.GetComponent<TMPro.TextMeshProUGUI>().fontStyle = TMPro.FontStyles.Bold;
        //Set color to red with alpha 0.8
        QuitButton.GetComponent<TMPro.TextMeshProUGUI>().color = new Color(1, 0, 0, 0.8f);
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

    // Update is called once per frame
    void Update()
    {
        
    }
}
