using UnityEngine;
using System.Collections;
using System.Collections.Generic;
public class Computer : MonoBehaviour
{
    [SerializeField]
    private GameObject canvas;
    [SerializeField]
    private GameObject screenExplosionParticleSystem;
    [SerializeField]
    private GameObject screenOff;
    [SerializeField]
    private GameObject screenOn;
    [SerializeField]
    private GameObject shards;
    private bool broken, breakable;

    private void Awake()
    {
        this.broken = false;
        this.breakable = false;
    }

    void Start()
    {
        
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            if (this.breakable)
            {
                MachineTextScript.UpdateMachine(1);
                TimerScript.TimerReset();
                this.Explode();
            }
        }
    }

    private bool Explode()
    {
        if (this.broken)
            return false;

        this.broken = true;
        this.breakable = false;
        this.canvas.SetActive(false);
        this.screenOff.SetActive(false);
        this.screenOn.SetActive(false);
        this.shards.SetActive(true);

        Rigidbody[] shardRBs = this.GetComponentsInChildren<Rigidbody>();
        this.screenExplosionParticleSystem.SetActive(true);
        foreach (Rigidbody shardRB in shardRBs)
        {
            float randomForce = Random.Range(1, 5);
            float randomRotationX = 0;
            float randomRotationY = Random.Range(-20, 20);
            float randomRotationZ = 0;
            shardRB.transform.Rotate(randomRotationX, randomRotationY, randomRotationZ);
            shardRB.AddRelativeForce(Vector3.forward * randomForce, ForceMode.Impulse);
        }

        return true;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            if (!this.broken)
            {
                this.breakable = true;
                this.screenOff.SetActive(false);
                this.screenOn.SetActive(true);
                this.shards.SetActive(false);
                this.canvas.SetActive(true);
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            if (!this.broken)
            {
                this.breakable = false;
                this.screenOff.SetActive(true);
                this.screenOn.SetActive(false);
                this.shards.SetActive(false);
                this.canvas.SetActive(false);
            }
        }
    }
}
