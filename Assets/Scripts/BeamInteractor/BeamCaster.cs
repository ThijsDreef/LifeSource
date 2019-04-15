using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(BeamVisualizer))]
public class BeamCaster : MonoBehaviour
{
    private List<Vector3> hitPoints = new List<Vector3>();
    private BeamVisualizer beamVisualizer;
    private const int MAX_DISTANCE = 25;
    private const int MAX_BOUNCE = 3;
    // Start is called before the first frame update
    void Start() {
        beamVisualizer = GetComponent<BeamVisualizer>();
    }

    private void FixedUpdate() {
        hitPoints.Clear();
        CalculateLine(transform.position, transform.forward);
        beamVisualizer.VisualDraw(hitPoints);
    }

    private void CalculateLine(Vector3 startPosition, Vector3 direction) {
        RaycastHit hit;
        if(hitPoints.Count < MAX_BOUNCE) {
        hitPoints.Add(startPosition);
        if(Physics.Raycast(startPosition, direction, out hit, MAX_DISTANCE)) {
            if(hit.collider.CompareTag("Reflectable")) {
                direction = Vector3.Reflect(hit.point - startPosition, hit.normal);
                CalculateLine(hit.point, direction);
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
}
