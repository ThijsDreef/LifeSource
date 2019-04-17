using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlantRotationInteraction : RotateInteractor {
    
    private Camera mainCamera;

    private void Start() {
        mainCamera = Camera.main;
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
