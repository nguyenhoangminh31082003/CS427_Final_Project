using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ComputerCollection : MonoBehaviour
{

    private GameObject[] computers;

    void Start()
    {
        if (this.computers == null)
            this.computers = GameObject.FindGameObjectsWithTag("Computer");

        foreach (GameObject computer in this.computers)
            Debug.Log(computer.name);
    }

    void Update()
    {
        
    }
}
