using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrbitalCamera : MonoBehaviour
{
	[SerializeField]
	private Vector3 target;

	private Vector3 oldMousePosition;
	#if (!UNITY_IPHONE || !UNITY_ANDROID)
		void Update() {
			if (Input.GetMouseButton(1)) OrbitCamera(target, (oldMousePosition.x - Input.mousePosition.x) * 0.2f, (oldMousePosition.y - Input.mousePosition.y) * 0.2f);
			oldMousePosition = Input.mousePosition;
		}

		public void OrbitCamera(Vector3 target, float y_rotate, float x_rotate) {
			Vector3 angles = transform.eulerAngles;
			angles.z = 0;
			transform.eulerAngles = angles;
			transform.RotateAround(target, Vector3.up, y_rotate);
			transform.RotateAround(target, Vector3.left, x_rotate);

			transform.LookAt(target);
		}
	#endif
}
