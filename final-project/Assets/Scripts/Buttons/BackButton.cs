using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackButton : BaseButton
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
