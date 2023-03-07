using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    private Vector3 cameraPosition;
    private const int scalingFactor = 10;
    
    [Header("Camera Settings")]
    public float cameraSpeed = 1;
    public float zoomSpeed = 10;

    void Start()
    {
        cameraPosition = transform.position;
    }

    void Update()
    {
        if (Input.GetKey(KeyCode.W))
        {
            cameraPosition.y += cameraSpeed / scalingFactor;
        }
        if (Input.GetKey(KeyCode.S))
        {
            cameraPosition.y -= cameraSpeed / scalingFactor;
        }
        if (Input.GetKey(KeyCode.A))
        {
            cameraPosition.x -= cameraSpeed / scalingFactor;
        }
        if (Input.GetKey(KeyCode.D))
        {
            cameraPosition.x += cameraSpeed / scalingFactor;
        }
    
        float scrollInput = Input.GetAxis("Mouse ScrollWheel");
        cameraPosition.z += scrollInput * zoomSpeed;
        transform.position = cameraPosition;
    }
}

