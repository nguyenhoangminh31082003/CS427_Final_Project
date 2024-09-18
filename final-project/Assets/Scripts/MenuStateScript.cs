using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuStateScript : MonoBehaviour
{
    [SerializeField] private GameObject playerAtMainMenu;
    [SerializeField] private GameObject playerAtOptionMenu;
    [SerializeField] private GameObject mainMenuCanvas;
    [SerializeField] private GameObject optionMenuCanvas;
    [SerializeField] private double numberOfMillisecondsForTransition = 1000;

    private bool isTransitioning = false;
    private bool isReverselyTransitioning = false;
    private float transitionProgress = 0f;
    private Vector3 startPosition;
    private Quaternion startRotation;
    private Vector3 endPosition;
    private Quaternion endRotation;

    public void StartTransition()
    {
        if (this.isTransitioning || this.isReverselyTransitioning)
            return;

        this.isTransitioning = true;
        this.transitionProgress = 0f;

        // Set up transition start and end positions
        this.startPosition = playerAtMainMenu.transform.position;
        this.startRotation = playerAtMainMenu.transform.rotation;
        this.endPosition = playerAtOptionMenu.transform.position;
        this.endRotation = playerAtOptionMenu.transform.rotation;

        // Disable the main menu and enable the option menu
        mainMenuCanvas.SetActive(false);
        optionMenuCanvas.SetActive(true);
    }

    public void StartReverseTransition()
    {
        if (this.isTransitioning || this.isReverselyTransitioning)
            return;

        this.isReverselyTransitioning = true;
        this.transitionProgress = 0f;

        // Set up reverse transition start and end positions
        this.startPosition = playerAtOptionMenu.transform.position;
        this.startRotation = playerAtOptionMenu.transform.rotation;
        this.endPosition = playerAtMainMenu.transform.position;
        this.endRotation = playerAtMainMenu.transform.rotation;

        // Disable the option menu and enable the main menu
        optionMenuCanvas.SetActive(false);
        mainMenuCanvas.SetActive(true);
    }

    void Update()
    {
        if (this.isTransitioning)
        {
            // Interpolate position and rotation based on time
            this.transitionProgress += Time.deltaTime / ((float)numberOfMillisecondsForTransition / 1000f);

            playerAtMainMenu.transform.position = Vector3.Lerp(startPosition, endPosition, transitionProgress);
            playerAtMainMenu.transform.rotation = Quaternion.Lerp(startRotation, endRotation, transitionProgress);

            // Stop transition when completed
            if (transitionProgress >= 1f)
            {
                this.isTransitioning = false;
            }
        }

        if (this.isReverselyTransitioning)
        {
            // Interpolate position and rotation based on time (reverse direction)
            this.transitionProgress += Time.deltaTime / ((float)numberOfMillisecondsForTransition / 1000f);

            playerAtOptionMenu.transform.position = Vector3.Lerp(startPosition, endPosition, transitionProgress);
            playerAtOptionMenu.transform.rotation = Quaternion.Lerp(startRotation, endRotation, transitionProgress);

            // Stop reverse transition when completed
            if (transitionProgress >= 1f)
            {
                this.isReverselyTransitioning = false;
            }
        }
    }
}
