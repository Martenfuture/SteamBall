using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class simpleCameraMovement : MonoBehaviour
{

    [SerializeField] GameObject playerGameObject;

    private Vector3 offset;
    // Start is called before the first frame update
    void Start()
    {
        offset = transform.position - playerGameObject.transform.position;
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = playerGameObject.transform.position + offset;
    }
}
