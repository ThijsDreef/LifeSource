using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(BeamVisualizer))]
public class BeamCaster : MonoBehaviour
{
    private List<Vector3> hitPoints = new List<Vector3>();
    private BeamVisualizer beamVisualizer;
    private const int MAX_DISTANCE = 10;
    // Start is called before the first frame update
    void Start() {
        beamVisualizer = GetComponent<BeamVisualizer>();

        StartMapping();
        beamVisualizer.VisualDraw(hitPoints);
    }

    private void StartMapping() {
        RaycastHit hit;
        hitPoints.Add(transform.position);
        if(Physics.Raycast(transform.position, Vector3.forward, out hit, MAX_DISTANCE)) {
            hitPoints.Add(hit.transform.position);
            if(hit.collider.CompareTag("Reflectable")) {
                Vector3.Reflect(hit.transform.position, hit.normal);
            }
        }
        else {
            hitPoints.Add(Vector3.forward * MAX_DISTANCE);
        }
    }
}
