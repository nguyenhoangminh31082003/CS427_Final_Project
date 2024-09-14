using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class TimerScript : MonoBehaviour
{
    static TimerScript TimerScriptInstance;
    [SerializeField] GameObject staticEffect;
    [SerializeField] GameObject gameOverText;
    // Start is called before the first frame update
    static float multi = 10.0f;
    static float targetTime = 60.0f;
    TextMeshProUGUI uGUI = null;

    private void Awake()
    {
        if (TimerScriptInstance == null)
        {
            TimerScriptInstance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    static public void TimerReset()
    {
        multi -= 0.5f;
        targetTime = multi * 60.0f;
    }

    void Start()
    {
        targetTime = multi * 60.0f;
        uGUI = GetComponent<TextMeshProUGUI>();
        staticEffect.SetActive(false);
    }

    // Update is called once per frame

    private void FixedUpdate()
    {
        if (GameState.gameOver)
        {
            return;
        }
        if (targetTime < (0.3f * multi * 60.0f))
        {
            staticEffect.SetActive(true);
            //Debug.Log("Effect On");
        }
        else
        {
            staticEffect.SetActive(false);
        }
    }

    void Update()
    {
        if (GameState.gameOver == true)
        {
            return;
        }
        targetTime -= Time.deltaTime;
        if (targetTime <= 0)
        {
            targetTime = 0;
            GameState.SetGameOver();
            gameOverText.SetActive(true);
        }
        uGUI.text = "Time: " + targetTime.ToString("F2");
    }
}
