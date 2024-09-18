using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuStateScript : MonoBehaviour
{
    [SerializeField] private GameObject playerAtMainMenu;   // Reference to Player's transform at the Main Menu
    [SerializeField] private GameObject playerAtOptionMenu; // Reference to Player's transform at the Option Menu
    [SerializeField] private GameObject mainMenuCanvas;     // Reference to the Main Menu Canvas
    [SerializeField] private GameObject optionMenuCanvas;   // Reference to the Option Menu Canvas
    [SerializeField] private double numberOfMillisecondsForTransition = 1000; // Time duration for the transition in milliseconds

    private bool isTransitioning = false;
    private bool isReversed = false;
    private float transitionProgress = 0f; // Tracks progress of the transition
    private float transitionDuration;      // Duration in seconds (converted from milliseconds)
    
    private Vector3 startPosition;         // Start position (Main Menu)
    private Quaternion startRotation;      // Start rotation (Main Menu)
    private Vector3 endPosition;           // End position (Option Menu)
    private Quaternion endRotation;        // End rotation (Option Menu)

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