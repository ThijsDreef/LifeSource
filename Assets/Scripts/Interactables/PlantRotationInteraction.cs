using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public class PlantRotationInteraction : RotateInteractor {
	private GameObject target;
	private Camera mainCamera;
	public Action shootStart;
	public Action shootStop;
	private void Start() {
		mainCamera = Camera.main;
		target = ParticleContainer.Instance.GetCrosshairTransform().gameObject;
		target.SetActive(true);
	}

	public override void StartInteract() {
		base.StartInteract();
		shootStart?.Invoke();
	}
	public override void StopInteract() {
		base.StopInteract();
		shootStop?.Invoke();
	}
	
	/// Points the direction to where the player looks with the camera. 
	protected override IEnumerator Interacting () {
		RaycastHit hit;
		while(true) {
			yield return new WaitForEndOfFrame();
			#if (!UNITY_IPHONE || !UNITY_ANDROID)
				if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hit)) {
					transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.LookRotation(hit.point - this.transform.position), Time.deltaTime * 6);
					target.transform.position = hit.point;
				} 
			#else 
				if(Physics.Raycast(mainCamera.transform.position, mainCamera.transform.forward, out hit)) {
					transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.LookRotation(hit.point - this.transform.position), Time.deltaTime * 6);
					target.transform.position = hit.point;
				}
			#endif
		}
	}
}
