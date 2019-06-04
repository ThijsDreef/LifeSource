using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Vuforia;

public class Follow : MonoBehaviour, ITrackableEventHandler {    
    private ImageTargetBehaviour trackerBehaviour;
    private GameObject tracker;
    Renderer[] renderers;

    public void OnTrackableStateChanged(TrackableBehaviour.Status previousStatus, TrackableBehaviour.Status newStatus) {
        for (int i = 0; i < renderers.Length; i++) {
            renderers[i].enabled = newStatus == TrackableBehaviour.Status.TRACKED;
        }
    }

  private void Start() {

        tracker = GameObject.FindGameObjectWithTag("Target");
        trackerBehaviour = tracker.GetComponent<ImageTargetBehaviour>();
        renderers = GetComponentsInChildren<Renderer>();

        this.transform.SetParent(tracker.transform);
        OverlayController.Instance.onStartOverlay.AddListener(this.destroyLevel);
        trackerBehaviour.RegisterTrackableEventHandler(this);
        OnTrackableStateChanged(TrackableBehaviour.Status.NO_POSE, trackerBehaviour.CurrentStatus);
    }

    private void destroyLevel() {
        Destroy(this.gameObject, 2.833f);
        trackerBehaviour.UnregisterTrackableEventHandler(this);
        OverlayController.Instance.onStartOverlay.RemoveListener(this.destroyLevel);
    }
}
