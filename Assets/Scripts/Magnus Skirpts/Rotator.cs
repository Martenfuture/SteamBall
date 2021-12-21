using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotator : MonoBehaviour
{
    public Quaternion startQuarternion;

    public Vector3 quaternionToCevtor;
    public Vector3 reverseQuaternion;

    public float lerpTime = 1;
    public float RotateAmound = 1;

    public bool rotate;
    public bool rotateConstantly;

    void Start()
    {
        startQuarternion = transform.rotation;
    }

    // Update is called once per frame
    void Update()
    {
      if(rotate)
        transform.rotation = Quaternion.Lerp(transform.rotation , Quaternion.Euler(reverseQuaternion) ,Time.deltaTime * lerpTime);
      if(rotateConstantly && !rotate)
        transform.Rotate(Vector3.up * RotateAmound); //right //up /forward
    }
    public void snapRotation()
    {
        transform.rotation = startQuarternion;
    }
}
