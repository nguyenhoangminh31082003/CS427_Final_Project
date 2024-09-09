using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ComputerCanvasPrompt : MonoBehaviour
{
    private Camera playerCamera;

    void Start()
    {
        GameObject gameObject = GameObject.FindGameObjectWithTag("TheCameraOfPlayer");
        this.playerCamera = gameObject.GetComponent<Camera>();
    }

    void Update()
    {
        
    }

    private void LateUpdate()
    {
        Quaternion rotation = this.playerCamera.transform.rotation;
        this.transform.LookAt(this.transform.position + rotation * Vector3.forward, rotation * Vector3.up);
    }
}
