using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuStateScript : MonoBehaviour
{
    [SerializeField] private GameObject player;
    [SerializeField] private GameObject playerAtMainMenu;   
    [SerializeField] private GameObject playerAtOptionMenu; 
    [SerializeField] private GameObject playerAtGuideMenu; 
    [SerializeField] private GameObject mainMenuCanvas;     
    [SerializeField] private GameObject optionMenuCanvas;  
    [SerializeField] private GameObject guideMenuCanvas;   
    [SerializeField] private double numberOfMillisecondsForTransition = 2000; 

    private bool isReversed = false;
    private float transitionProgress = 0f; 
    private float transitionDuration;      // Duration in seconds (converted from milliseconds)
    
    private Vector3 startPosition;         
    private Quaternion startRotation;      
    private Vector3 endPosition;           
    private Quaternion endRotation;      

    private GameObject targetMenuCanvas = null;  

    void Start()
    {
        this.transitionDuration = (float)numberOfMillisecondsForTransition / 1000f; // Convert milliseconds to seconds
    }

    private void TurnOffAllMenuCanvas() 
    {
        this.mainMenuCanvas.SetActive(false); 
        this.optionMenuCanvas.SetActive(false);
        this.guideMenuCanvas.SetActive(false);
    }

    public void StartTransitionToOptionMenu()
    {
        if (this.targetMenuCanvas != null)
            return;

        this.startPosition = this.player.transform.position;
        this.startRotation = this.player.transform.rotation;
        this.endPosition = this.playerAtOptionMenu.transform.position;
        this.endRotation = this.playerAtOptionMenu.transform.rotation;

        this.targetMenuCanvas = this.optionMenuCanvas;
        this.transitionProgress = 0f;

        this.TurnOffAllMenuCanvas();
    }

    public void StartTransitionToMainMenu()
    {
        if (this.targetMenuCanvas != null)
            return;

        this.startPosition = this.player.transform.position;
        this.startRotation = this.player.transform.rotation;
        this.endPosition = this.playerAtMainMenu.transform.position;
        this.endRotation = this.playerAtMainMenu.transform.rotation;

        this.targetMenuCanvas = this.mainMenuCanvas;
        this.transitionProgress = 0f;

        this.TurnOffAllMenuCanvas();
    }

    public void StartTransitionToGuideMenu()
    {
        if (this.targetMenuCanvas != null)
            return;

        this.startPosition = this.player.transform.position;
        this.startRotation = this.player.transform.rotation;
        this.endPosition = this.playerAtGuideMenu.transform.position;
        this.endRotation = this.playerAtGuideMenu.transform.rotation;

        this.targetMenuCanvas = this.guideMenuCanvas;
        this.transitionProgress = 0f;

        this.TurnOffAllMenuCanvas();
    }

    void Update()
    {
        if (this.targetMenuCanvas != null)
        {
            this.transitionProgress += Time.deltaTime / this.transitionDuration;

            this.player.transform.position = Vector3.Lerp(this.startPosition, this.endPosition, this.transitionProgress);
            this.player.transform.rotation = Quaternion.Slerp(this.startRotation, this.endRotation, this.transitionProgress);

            if (this.transitionProgress >= 1f)
            {
                this.player.transform.position = endPosition;
                this.player.transform.rotation = endRotation;

                this.targetMenuCanvas.SetActive(true);

                this.targetMenuCanvas = null;                
            }
        }
    }
}