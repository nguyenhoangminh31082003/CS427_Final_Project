using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GuideButton : BaseButton
{
    public override void OnPointerClicking()
    {
        base.OnPointerClicking();
        /*
        
            Let MenuStateScript.StartTransition handle the transition between the Main Menu and the Option Menu.
        
        */
    }

    void Start()
    {
        
    }

    void Update()
    {
    }
}
