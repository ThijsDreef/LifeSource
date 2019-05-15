using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ARMovement : MonoBehaviour
{
    private Transform imageTarget;
    public float smoothness;
    public float rotationStrength;
    private Vector3 velocity = Vector3.zero;

    private void Awake() {
        imageTarget = GameObject.FindGameObjectWithTag("Target").transform;
    }

    /// Lest the object move smooth between positions, helps against jitters.
    private void LateUpdate() {
        transform.position = Vector3.SmoothDamp(transform.position, imageTarget.position, ref velocity, smoothness);
        transform.rotation = Quaternion.Slerp(transform.rotation, imageTarget.rotation, rotationStrength);
    }
}
