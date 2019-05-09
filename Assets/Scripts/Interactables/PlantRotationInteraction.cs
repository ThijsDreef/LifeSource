using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public class PlantRotationInteraction : RotateInteractor {
    private Camera mainCamera;
    public Action shootStart;
    public Action shootStop;
    private void Start() {
        mainCamera = Camera.main;
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
            if(Physics.Raycast(mainCamera.transform.position, mainCamera.transform.forward, out hit)) {
                transform.LookAt(hit.point);
            }
        }
    }
}
