using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Vuforia;

public class Follow : MonoBehaviour{    
    private void Awake() {
        GameObject tracker = GameObject.FindGameObjectWithTag("Target");
        Renderer[] renders = GetComponentsInChildren<Renderer>();
        for (int i = 0; i < renders.Length; i++) renders[i].enabled = false;
        this.transform.SetParent(tracker.transform);
        OverlayController.Instance.onStartOverlay.AddListener(this.destroyLevel);
    }

    private void destroyLevel() {
        Destroy(this.gameObject, 2.833f);
        OverlayController.Instance.onStartOverlay.RemoveListener(this.destroyLevel);
    }
}
