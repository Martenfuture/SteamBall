using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rotate : MonoBehaviour
{
    
    public float rotationSpeed;
    public GameObject camera;
    public float rotationOffset;

    void Update()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        Vector3 movementDirection = Quaternion.Euler(0, camera.transform.eulerAngles.y + rotationOffset, 0) * new Vector3(verticalInput, 0, -horizontalInput); // added roatation relevant to the camera
        movementDirection.Normalize();

        


        if (movementDirection != Vector3.zero)
        {
            Quaternion toRotation = Quaternion.LookRotation(movementDirection, Vector3.up);
            transform.rotation = Quaternion.RotateTowards(transform.rotation, toRotation, rotationSpeed * Time.deltaTime);
        }
    }
}
