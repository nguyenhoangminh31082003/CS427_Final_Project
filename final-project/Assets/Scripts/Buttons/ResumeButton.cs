using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ResumeButton : BaseButton
{
    [SerializeField] GameObject inGameMenuCanvas;
    public override void OnPointerClicking()
    {
        base.OnPointerClicking();
        Time.timeScale = 1;
        this.inGameMenuCanvas.SetActive(false);
    }

    void Start()
    {
        
    }

    void Update()
    {
        //Debug.Log("Resume button - Cursor: " + Cursor.visible); 
    }
}
