using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ResumeButton : BaseButton
{
    [SerializeField] private GameObject inGameMenuCanvas;
    [SerializeField] private GameObject player;

    public override void OnPointerClicking()
    {
        base.OnPointerClicking();
        this.inGameMenuCanvas.SetActive(false);
        this.player.GetComponent<SC_FPSController>().EnableMovement();
        Time.timeScale = 1;
    }

    void Start()
    {
        
    }

    void Update()
    {
    }
}
