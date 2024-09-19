using TMPro;
using System;
using UnityEngine;
using System.Collections;
using Unity.VisualScripting;
using System.Collections.Generic;

public class TimerScript : MonoBehaviour
{
    static TimerScript TimerScriptInstance;
    [SerializeField] GameObject staticEffect;
    [SerializeField] GameObject gameOverText;

    static float multi = 100.0f;
    static float targetTime = 60.0f;

    TextMeshProUGUI uGUI = null;

    static public void SetInitialGameDuration(float minutes)
    {
        multi = minutes;
    }

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

    private void FixedUpdate()
    {
        if (GameState.gameOver)
        {
            return;
        }
        if (targetTime < (0.1f * multi * 60.0f))
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
