using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class move : MonoBehaviour
{
    public GameObject head;
    void Update()
    {
        head.transform.position = transform.position;
    }
}