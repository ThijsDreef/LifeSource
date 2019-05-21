using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(BeamVisualizer))]
public class BeamCaster : MonoBehaviour {
    [SerializeField] 
    private Transform target;
    [SerializeField]
    private Vector3 offset;
    private List<Vector3> hitPoints = new List<Vector3>();
    private List<Transform> objectTransforms = new List<Transform>();
    private GameObject interactable;
    private BeamVisualizer beamVisualizer;
    private const int MAX_DISTANCE = 150;
    private const int MAX_BOUNCE = 5;

    private void Awake() {
        beamVisualizer = GetComponent<BeamVisualizer>();
    }

    private void Update() {
        if(RotationCheck()) {
            UpdateHitPoints();
            beamVisualizer.VisualDraw(hitPoints);
        }        
    }

    /// Called every frame the object is rotated to update the points.
    private void UpdateHitPoints() {
        transform.LookAt(ParticleContainer.Instance.GetCrosshairTransform());

        hitPoints.Clear();
        objectTransforms.Clear();
        interactable = null;
        CalculateHitPoints(transform.position, transform.forward);
        hitPoints[0] += offset;
    }

    /// Cast a ray from the start position to the next object, if that object is able to reflect the beam will reflect to the next until it hits something else or hits nothing.
    private void CalculateHitPoints(Vector3 startPosition, Vector3 direction) {
        RaycastHit hit;
        hitPoints.Add(startPosition);
        if(Physics.Raycast(startPosition, direction, out hit, MAX_DISTANCE) && hitPoints.Count < MAX_BOUNCE) {
            objectTransforms.Add(hit.collider.gameObject.transform);
            
            if(interactable != hit.collider.gameObject && (hit.collider.CompareTag("Reflectable") || hit.collider.CompareTag("Interactable"))) {
                interactable = hit.collider.gameObject;
                interactable.GetComponent<Interactable>()?.OnBeamHit();
            }
            if(hit.collider.CompareTag("Reflectable")) {
                direction = hit.transform.forward;
                CalculateHitPoints(hit.transform.position, direction);
            }
            else {
                hitPoints.Add(hit.point);
            }
        }
        else {
            hitPoints.Add(startPosition + direction * MAX_DISTANCE);
        }           
    }

    /// Checks if an object is rotated.
    private bool RotationCheck() {
        bool rotationCheck = false;
        for(int i = 0; i < objectTransforms.Count; i ++) {
            if(objectTransforms[i] != null && objectTransforms[i].hasChanged) {
                rotationCheck = true;
                break;
            }
        }
        return rotationCheck || transform.hasChanged;
    }
}