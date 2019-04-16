using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(BeamVisualizer))]
public class BeamCaster : MonoBehaviour
{
    private List<Vector3> hitPoints = new List<Vector3>();
    private List<Transform> objectTransforms = new List<Transform>();
    private List<Quaternion> objectRotations = new List<Quaternion>();
    private GameObject interactable;
    private Quaternion currentRotation;
    private BeamVisualizer beamVisualizer;
    private const int MAX_DISTANCE = 25;
    private const int MAX_BOUNCE = 5;

    private void Awake() {
        beamVisualizer = GetComponent<BeamVisualizer>();
    }

    private void FixedUpdate() {
        if(RotationCheck()) {
            currentRotation = transform.rotation;
            UpdateHitPoints();
            beamVisualizer.VisualDraw(hitPoints);
        }        
    }

    /// Called every frame the object is rotated to update the points.
    private void UpdateHitPoints() {
        hitPoints.Clear();
        CalculateHitPoints(transform.position, transform.forward);
    }

    /// Cast a ray from the start position to the next object, if that object is able to reflect the beam will reflect to the next until it hits something else or hits nothing.
    private void CalculateHitPoints(Vector3 startPosition, Vector3 direction) {
        RaycastHit hit;
        hitPoints.Add(startPosition);
        if(Physics.Raycast(startPosition, direction, out hit, MAX_DISTANCE) && hitPoints.Count < MAX_BOUNCE) {
            objectTransforms.Add(hit.collider.gameObject.transform);
            objectRotations.Add(hit.collider.gameObject.transform.rotation);
            
            if(interactable != hit.collider.gameObject && hit.collider.CompareTag("Reflectable") || hit.collider.CompareTag("Interactable")) {
                interactable = hit.collider.gameObject;
                interactable.GetComponent<Interactable>()?.OnBeamHit();
            }
            if(hit.collider.CompareTag("Reflectable")) {
                direction = Vector3.Reflect(hit.point - startPosition, hit.normal);
                CalculateHitPoints(hit.point, direction);
            }
            else {
                hitPoints.Add(hit.transform.position);
            }
        }
        else {
            hitPoints.Add(startPosition + direction * MAX_DISTANCE);
        }           
    }

    /// Checks if an object is rotated.
    private bool RotationCheck() {
        bool rotationCheck = false;
        if(currentRotation != transform.rotation) {
            rotationCheck = true;
        }
        for(int i = 0; i < objectRotations.Count; i ++) {
            if(objectRotations[i] != objectTransforms[i].rotation) {
                rotationCheck = true;
                print("rotated");
            }
        }
        return rotationCheck;
    }
}