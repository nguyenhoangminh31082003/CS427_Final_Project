using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
        
    }
}
