using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(BeamVisualizer))]
public class BeamCaster : MonoBehaviour
{
    private List<Vector3> hitPoints = new List<Vector3>();
    private Vector3 rotationCheck;
    private GameObject interactable;
    private BeamVisualizer beamVisualizer;
    private const int MAX_DISTANCE = 25;
    private const int MAX_BOUNCE = 5;

    void Start() {
        beamVisualizer = GetComponent<BeamVisualizer>();
        rotationCheck = transform.rotation.eulerAngles;
    }

    private void FixedUpdate() {
        if(rotationCheck != transform.rotation.eulerAngles) {
            UpdateHitPoints();
        }        
    }

    /// Called every frame the object is rotated to update the points.
    private void UpdateHitPoints() {
        rotationCheck = transform.rotation.eulerAngles;
        hitPoints.Clear();
        CalculateHitPoints(transform.position, transform.forward);
        beamVisualizer.VisualDraw(hitPoints);
    }

    /// Cast a ray from the start position to the next object, if that object is able to reflect the beam will reflect to the next until it hits something else or hits nothing.
    private void CalculateHitPoints(Vector3 startPosition, Vector3 direction) {
        RaycastHit hit;
        hitPoints.Add(startPosition);
        if(Physics.Raycast(startPosition, direction, out hit, MAX_DISTANCE) && hitPoints.Count < MAX_BOUNCE) {
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
}
