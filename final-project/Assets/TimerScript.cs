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
    // Start is called before the first frame update
    static float multi = 5.0f;
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
        if (targetTime < (0.9f * multi * 60.0f))
        {
            staticEffect.SetActive(true);
            Debug.Log("Effect On");
        }
        else
        {
            staticEffect.SetActive(false);
        }
    }

    void Update()
    {
        targetTime -= Time.deltaTime;
        uGUI.text = "Time: " + targetTime.ToString("F2");
    }
}
