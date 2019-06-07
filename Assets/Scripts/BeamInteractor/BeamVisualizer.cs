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

    /// draws the vector3 list with hits as lines
    public void VisualDraw(List<Vector3> hits) {
        lineRenderer.positionCount = hits.Count;
        lineRenderer.SetPositions(hits.ToArray());
    }
}
