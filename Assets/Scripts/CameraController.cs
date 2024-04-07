using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public float rotationSpeed = 1f;
    // Update is called once per frame
    void Update()
    {
        float horizontalInput = Input.GetAxis("Mouse X");
        float verticalInput = Input.GetAxis("Mouse Y");

        Vector3 rotation = new Vector3(-verticalInput, horizontalInput, 0) * rotationSpeed;
        transform.Rotate(rotation);     
    }
}
