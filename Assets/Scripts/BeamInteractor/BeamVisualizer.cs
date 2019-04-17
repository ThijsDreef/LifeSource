using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(LineRenderer))]
public class BeamVisualizer : MonoBehaviour
{
    private LineRenderer lineRenderer;

    private void Awake() {
        lineRenderer = GetComponent<LineRenderer>();
    }

    public void VisualDraw(List<Vector3> hits) {
        lineRenderer.positionCount = hits.Count;
        for(int i = 0; i < hits.Count; i++) {
            lineRenderer.SetPosition(i, hits[i]);
        }
    }
}
