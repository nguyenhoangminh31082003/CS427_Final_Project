using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class MachineTextScript : MonoBehaviour
{
    static MachineTextScript MachineTextInstance;
    static public int total = 0;
    static TextMeshProUGUI textMesh = null;
    // Start is called before the first frame update
    private void Awake()
    {
        if (MachineTextInstance == null)
        {
            MachineTextInstance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void Start()
    {
        textMesh = GetComponent<TextMeshProUGUI>();
    }

    // Update is called once per frame

    static public void UpdateMachine(int inc = 1)
    {
        total += inc;
        if (inc > 0)
        {
            textMesh.text = "Machine: " + total.ToString() + "/8";
        }
    }

    void Update()
    {
        
    }
}
