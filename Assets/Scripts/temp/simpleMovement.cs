using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class simpleMovement : MonoBehaviour
{
    [SerializeField] float speed = 1;


    void Update()
    {
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");

        Rigidbody myRigidBody = gameObject.GetComponent<Rigidbody>();


        myRigidBody.AddForce(Vector3.right * v * speed);
        myRigidBody.AddForce(Vector3.back * h * speed);
    }
}
