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
        float distanceToPlayer = Vector3.Distance(transform.position, player.position);
        if (distanceToPlayer <= staticActivationRange)
        {
            if (staticObject != null && !staticObject.activeSelf)
            {
                staticObject.SetActive(true);
            }
        }
        else
        {
            if (staticObject != null && staticObject.activeSelf)
            {
                staticObject.SetActive(false);
            }
        }
    }

    private void DecideTeleportAction()
    {
        float randomValue = Random.value;

        if (randomValue <= chaseProbability)
        {
            TeleportNearPlayer();
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
        

        int maxAttempts = 20; // Limit the number of attempts to avoid infinite loops
        do
        {
            randomPosition = player.position + Random.onUnitSphere * teleportDistance;
        }
        while (GetComponent<TargetVisible>().IsVisible(randomPosition) && --maxAttempts > 0);
        randomPosition.y = transform.position.y; // Keep the same Y position
        transform.position = randomPosition;
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
}
