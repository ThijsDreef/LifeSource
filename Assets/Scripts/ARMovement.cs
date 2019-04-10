using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ARMovement : MonoBehaviour
{
    public Transform imageTarget;
    public float smoothness;
    public float rotationStrength;
    private Vector3 velocity = Vector3.zero;

    // Update is called once per frame
    void LateUpdate()
    {
        transform.position = Vector3.SmoothDamp(transform.position, imageTarget.position, ref velocity, smoothness);
        transform.rotation = Quaternion.Slerp(transform.rotation, imageTarget.rotation, rotationStrength);
    }
}
