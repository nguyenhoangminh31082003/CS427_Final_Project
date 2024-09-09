using System;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ComputerCollection : MonoBehaviour
{
    [SerializeField] private int numberOfChosenComputers;
    private GameObject[] computers;

    void Start()
    {
        if (this.computers == null)
            this.computers = GameObject.FindGameObjectsWithTag("Computer");

        this.numberOfChosenComputers = Math.Min(Math.Max(0, numberOfChosenComputers), this.computers.Length);
    }

    public int GetNumberOfChosenComputers()
    {
        return this.numberOfChosenComputers;
    }

    void Update()
    {
        
    }
}
