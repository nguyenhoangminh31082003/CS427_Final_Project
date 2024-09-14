using System;
using UnityEngine;

public class SlenderManAI : MonoBehaviour
{
    public Transform player; // Reference to the player's GameObject
    public float teleportDistance = 10f; // Maximum teleportation distance
    public float teleportCooldown = 5f; // Time between teleportation attempts
    public float returnCooldown = 10f; // Time before returning to base spot
    [Range(0f, 1f)] public float chaseProbability = 0.65f; // Probability of chasing the player
    public float rotationSpeed = 20f; // Rotation speed when looking at the player
    public AudioClip teleportSound; // Reference to the teleport sound effect
    private AudioSource audioSource;

    public GameObject staticObject; // Reference to the "static" GameObject
    public float staticActivationRange = 5f; // Range at which "static" should be activated

    private Vector3 baseTeleportSpot;
    private float teleportTimer;

    [SerializeField] private bool isVisible = false;

    [SerializeField] private LayerMask terrainLayerMask;

    private void Start()
    {
        baseTeleportSpot = transform.position;
        teleportTimer = teleportCooldown;

        // Get or add an AudioSource component
        audioSource = GetComponent<AudioSource>();
        if (audioSource == null)
        {
            audioSource = gameObject.AddComponent<AudioSource>();
        }

        // Set the teleport sound
        audioSource.clip = teleportSound;

        // Ensure the "static" object is initially turned off
        if (staticObject != null)
        {
            staticObject.SetActive(false);
        }

         GameObject terrainWrapper = GameObject.FindGameObjectWithTag("Terrain");
        if (terrainWrapper != null)
        {
            terrainLayerMask = 1 << terrainWrapper.layer;
        }
        else
        {
            Debug.LogError("Terrain wrapper object not found!");
        }
    }

    private void Update()
    {

        if (player == null)
        {
           
            return;
        }

        teleportTimer -= Time.deltaTime;

        // Teleport only if player does not see slender
        if (!isVisible) 
        {
            if (teleportTimer <= 0f)
            {
                DecideTeleportAction();
                teleportTimer = teleportCooldown;
            }
        }
        RotateTowardsPlayer();
        
        // Check player distance and toggle the "static" object accordingly
        //float distanceToPlayer = Vector3.Distance(transform.position, player.position);
        //if (distanceToPlayer <= staticActivationRange)
        //{
        //    if (staticObject != null && !staticObject.activeSelf)
        //    {
        //        staticObject.SetActive(true);
        //    }
        //}
        //else
        //{
        //    if (staticObject != null && staticObject.activeSelf)
        //    {
        //        staticObject.SetActive(false);
        //    }
        //}
    }

    private void DecideTeleportAction()
    {
        float randomValue = UnityEngine.Random.value;
        Console.WriteLine("Decide to teleport");
        if (randomValue <= chaseProbability)
        {
            TeleportNearPlayer();
            Console.WriteLine("Decide to teleport near player");
        }
        else
        {
            TeleportToBaseSpot();
        }
        // Play the teleport sound
        audioSource.Play();
    }

    private void TeleportNearPlayer()
    {
        Vector3 randomPosition;
        int maxAttempts = 100;

        do
        {
            Vector2 randomCircle = UnityEngine.Random.insideUnitCircle * teleportDistance;
            randomPosition = player.position + new Vector3(randomCircle.x, 0, randomCircle.y);
            randomPosition = GetTerrainPos(randomPosition.x, randomPosition.z);
        }
        while (GetComponent<TargetVisible>().IsVisible(randomPosition) && --maxAttempts > 0);

        if (maxAttempts > 0)
        {
            transform.position = randomPosition;
        }
        else
        {
            Debug.LogWarning("Failed to find a valid teleport position.");
            // Implement fallback behavior here
        }
    }

    private void TeleportToBaseSpot()
    {
        transform.position = baseTeleportSpot;
    }

    private void RotateTowardsPlayer()
    {
        Vector3 directionToPlayer = player.position - transform.position;
        directionToPlayer.y = 0f; // Ignore the vertical component

        if (directionToPlayer != Vector3.zero)
        {
            Quaternion targetRotation = Quaternion.LookRotation(directionToPlayer);
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);
        }
    }

    public void SetIsVisible(bool IsVisible) {
        isVisible = IsVisible;
    }

     private Vector3 GetTerrainPos(float x, float z)
    {
        Vector3 origin = new Vector3(x, 1000, z);
        RaycastHit hit;

        if (Physics.Raycast(origin, Vector3.down, out hit, Mathf.Infinity, terrainLayerMask))
        {
            return hit.point;
        }
        else
        {
            Debug.LogWarning($"Raycast failed to hit terrain at ({x}, {z}). Using fallback height.");
            return new Vector3(x, 0, z);
        }
    }
}
