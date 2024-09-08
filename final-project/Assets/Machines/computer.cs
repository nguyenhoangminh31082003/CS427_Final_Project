using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Computer : MonoBehaviour
{

    [SerializeField]
    private GameObject screenExplosionParticleSystem;
    [SerializeField]
    private GameObject screenOff;
    [SerializeField]
    private GameObject screenOn;
    [SerializeField]
    private GameObject shards;
    private bool broken;

    private void Awake()
    {
        this.broken = false;
    }

    void Start()
    {
        
    }

    void Update()
    {
        
    }

    private bool Explode()
    {
        if (this.broken)
            return false;

        this.broken = true;
        this.screenOff.SetActive(false);
        this.screenOn.SetActive(false);
        this.shards.SetActive(true);
        Rigidbody[] shardRBs = this.GetComponentsInChildren<Rigidbody>();
        this.screenExplosionParticleSystem.SetActive(true);
        foreach (Rigidbody shardRB in shardRBs)
        {
            float randomForce = Random.Range(1, 5);
            float randomRotationX = Random.Range(-20, 20);
            float randomRotationY = Random.Range(-20, 20);
            float randomRotationZ = Random.Range(-20, 20);
            shardRB.transform.Rotate(randomRotationX, randomRotationY, randomRotationZ);
            shardRB.AddRelativeForce(Vector3.forward * randomForce, ForceMode.Impulse);
        }

        return true;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Debug.Log("GameObject Player has entered the sphere collider of GameObject Computer.");
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Debug.Log("GameObject Player has exited the sphere collider of GameObject Computer.");
        }
    }
}
