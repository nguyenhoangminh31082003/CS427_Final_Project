using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;

public class QuitButton : BaseButton
{

    public override void OnPointerClicking()
    {
        base.OnPointerClicking();
        Time.timeScale = 1;
        SceneManager.LoadScene(0);
    }

    void Start()
    {
        
    }

    void Update()
    {
        
    }
}
