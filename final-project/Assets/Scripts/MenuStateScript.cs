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
        //if (this.isTransitioning)
        //   return false;
        if (this.isTransitioning)
            return;

        // Set up initial positions/rotations for the transition
        startPosition = playerAtMainMenu.transform.position;
        startRotation = playerAtMainMenu.transform.rotation;
        endPosition = playerAtOptionMenu.transform.position;
        endRotation = playerAtOptionMenu.transform.rotation;

        this.isTransitioning = true;
        transitionProgress = 0f; // Reset transition progress
        //return true;
    }

    void Update()
    {
        if (this.isTransitioning)
        {
            // Increment progress based on elapsed time
            transitionProgress += Time.deltaTime / transitionDuration;

            // Lerp position and rotation based on transitionProgress (0 to 1)
            playerAtMainMenu.transform.position = Vector3.Lerp(startPosition, endPosition, transitionProgress);
            playerAtMainMenu.transform.rotation = Quaternion.Slerp(startRotation, endRotation, transitionProgress);

            // Once the transition completes
            if (transitionProgress >= 1f)
            {
                // Finalize the position and rotation
                playerAtMainMenu.transform.position = endPosition;
                playerAtMainMenu.transform.rotation = endRotation;

                // Set the transition flag back to false
                this.isTransitioning = false;

                // Optionally, toggle menus visibility or handle other transition completion logic
                mainMenuCanvas.SetActive(false);  // Disable main menu canvas
                optionMenuCanvas.SetActive(true); // Enable option menu canvas
            }
        }
    }
}
