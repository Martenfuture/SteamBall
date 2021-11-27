using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]

public class move : MonoBehaviour
{

    public float xForce = 10.0f;
    public float zForce = 10.0f;
    public float yForce = 10.0f;

    //use this for initialization  

    void Start()
    {

    }
    //Update is called once per frame  
    void Update()
    {
        //this is for x axis' movement  

        float x = 0.0f;
        if (Input.GetKey(KeyCode.A))
        {
            x = x - xForce;
        }

        if (Input.GetKey(KeyCode.D))
        {
            x = x + xForce;
        }

        //this is for z axis' movement  

        float z = 0.0f;
        if (Input.GetKey(KeyCode.S))
        {
            z = z - zForce;
        }

        if (Input.GetKey(KeyCode.W))
        {
            z = z + zForce;
        }
        //this is for z axis' movement  

        float y = 0.0f;
        if (Input.GetKeyDown(KeyCode.Space))
        {
            y = yForce;
        }

        GetComponent<Rigidbody>().AddForce(x, y, z);
    }
}
