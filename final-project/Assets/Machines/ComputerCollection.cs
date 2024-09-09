using System;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ComputerCollection : MonoBehaviour
{
    [SerializeField] private int numberOfChosenComputers;
    [SerializeField] private double recommendedDistance;
    [SerializeField] private bool choosingAllComputers;
    private GameObject[] computers, chosenComputers;

    void Start()
    {
        if (this.computers == null)
            this.computers = GameObject.FindGameObjectsWithTag("Computer");

        this.numberOfChosenComputers = Math.Min(Math.Max(0, numberOfChosenComputers), this.computers.Length);
    
        this.recommendedDistance = Math.Abs(this.recommendedDistance);
    
        if (this.chosenComputers == null)
        {
            if (this.choosingAllComputers)
                this.chosenComputers = this.computers;
            else
            {
                int chosenComputerCount = 0, computerCount = this.computers.Length, selectedIndex;
                bool[] selected = new bool[computerCount];
                double minimum, maximum;

                this.ShuffleComputers();

                this.chosenComputers = new GameObject[this.numberOfChosenComputers];

                for (int i = 0; i < computerCount && chosenComputerCount < this.numberOfChosenComputers; ++i)
                {
                    selected[i] = true;
                    for (int j = 0; j < chosenComputerCount; ++j)
                        if (Vector3.Distance(this.chosenComputers[j].transform.position, this.computers[i].transform.position) < this.recommendedDistance)
                        {
                            selected[i] = false;
                            break;
                        }

                    if (selected[i])
                    {
                        this.chosenComputers[chosenComputerCount++] = this.computers[i];
                    }
                }

                while (chosenComputerCount < this.numberOfChosenComputers)
                {
                    maximum = Double.NegativeInfinity;
                    selectedIndex = -1;
                    for (int i = 0; i < computerCount; ++i)
                    {
                        if (selected[i])
                            continue;
                        minimum = Double.PositiveInfinity;
                        for (int j = 0; j < chosenComputerCount; ++j)
                            minimum = Math.Min(minimum, Vector3.Distance(this.chosenComputers[j].transform.position, this.computers[i].transform.position));
                        if (maximum < minimum)
                        {
                            maximum = minimum;
                            selectedIndex = i;
                        }
                    }
                    if (selectedIndex < 0)
                        break;
                    selected[selectedIndex] = true;
                    this.chosenComputers[chosenComputerCount++] = this.computers[selectedIndex];
                }

                while (chosenComputerCount < this.numberOfChosenComputers)
                {
                    maximum = Double.NegativeInfinity;
                    selectedIndex = -1;
                    for (int i = 0; i < computerCount; ++i)
                    {
                        if (selected[i])
                            continue;
                        minimum = 0;
                        for (int j = 0; j < chosenComputerCount; ++j)
                            minimum += Vector3.Distance(this.chosenComputers[j].transform.position, this.computers[i].transform.position);
                        if (maximum < minimum)
                        {
                            maximum = minimum;
                            selectedIndex = i;
                        }
                    }
                    if (selectedIndex < 0)
                        break;
                    selected[selectedIndex] = true;
                    this.chosenComputers[chosenComputerCount++] = this.computers[selectedIndex];
                }

                for (int i = 0; i < computerCount && chosenComputerCount < this.numberOfChosenComputers; ++i)
                {
                    if (selected[i])
                        continue;
                    selected[i] = true;
                    this.chosenComputers[chosenComputerCount++] = this.computers[i];
                }

                for (int i = 0; i < computerCount; ++i)
                {
                    this.computers[i].SetActive(selected[i]);
                    if (selected[i])
                        Debug.Log(i + " is chosen!!! (" + this.computers[i].name + ")");
                }
            }
        }
    }
    private void ShuffleComputers()
    {
        for (int i = this.computers.Length - 1; i > 0; i--)
        {
            int randomIndex = UnityEngine.Random.Range(0, i + 1);
            GameObject temp = this.computers[i];
            this.computers[i] = this.computers[randomIndex];
            this.computers[randomIndex] = temp;
        }
    }

    public int GetNumberOfChosenComputers()
    {
        return this.numberOfChosenComputers;
    }

    void Update()
    {
        
    }
}
