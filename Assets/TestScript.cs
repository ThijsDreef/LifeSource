using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestScript : MonoBehaviour
{
    [SerializeField]
    private Transform ImageTarget;
    private Vector3 oldPosition;
    private void Update() {
		oldPosition = ImageTarget.transform.position;

	}
	private void LateUpdate() {
		transform.position += ImageTarget.transform.position - oldPosition;
	}
}