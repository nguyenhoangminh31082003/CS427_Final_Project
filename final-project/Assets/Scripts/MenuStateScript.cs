using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuStateScript : MonoBehaviour
{
    [SerializeField] private GameObject playerAtMainMenu;   
    [SerializeField] private GameObject playerAtOptionMenu; 
    [SerializeField] private GameObject mainMenuCanvas;     
    [SerializeField] private GameObject optionMenuCanvas;   
    [SerializeField] private double numberOfMillisecondsForTransition = 2000; // Time duration for the transition in milliseconds

    private bool isTransitioning = false;
    private bool isReversed = false;
    private float transitionProgress = 0f; 
    private float transitionDuration;      // Duration in seconds (converted from milliseconds)
    
    private Vector3 startPosition;         
    private Quaternion startRotation;      
    private Vector3 endPosition;           
    private Quaternion endRotation;        

    void Start()
    {
        transitionDuration = (float)numberOfMillisecondsForTransition / 1000f; // Convert milliseconds to seconds
    }

    public void StartTransition()
    {
        if (this.isTransitioning)
            return;

        startPosition = playerAtMainMenu.transform.position;
        startRotation = playerAtMainMenu.transform.rotation;
        endPosition = playerAtOptionMenu.transform.position;
        endRotation = playerAtOptionMenu.transform.rotation;

        this.isTransitioning = true;
        this.isReversed = false;
        transitionProgress = 0f;

        mainMenuCanvas.SetActive(false); 
        optionMenuCanvas.SetActive(false);
    }

    public void StartReversedTransition()
    {
        if (this.isTransitioning)
            return;

        (startPosition, endPosition) = (endPosition, startPosition);
        (startRotation, endRotation) = (endRotation, startRotation);

        this.isTransitioning = true;
        this.isReversed = true;
        transitionProgress = 0f;

        mainMenuCanvas.SetActive(false); 
        optionMenuCanvas.SetActive(false);
    }

    void Update()
    {
        if (this.isTransitioning)
        {
            //Debug.Log(startPosition + " " + endPosition + " " + startRotation + " " + endRotation + " " + transitionProgress + " " + playerAtMainMenu.transform.position + " " + playerAtMainMenu.transform.rotation); 
            transitionProgress += Time.deltaTime / transitionDuration;

            playerAtMainMenu.transform.position = Vector3.Lerp(startPosition, endPosition, transitionProgress);
            playerAtMainMenu.transform.rotation = Quaternion.Slerp(startRotation, endRotation, transitionProgress);

            if (transitionProgress >= 1f)
            {
                playerAtMainMenu.transform.position = endPosition;
                playerAtMainMenu.transform.rotation = endRotation;

                this.isTransitioning = false;

                if (this.isReversed)
                {
                    mainMenuCanvas.SetActive(true);  
                    optionMenuCanvas.SetActive(false); 
                } else {
                    mainMenuCanvas.SetActive(false); 
                   optionMenuCanvas.SetActive(true); 
                }
                
            }
        }
    }
}