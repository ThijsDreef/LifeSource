﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class OverlayController : MonoBehaviour {

    public static OverlayController Instance;
    public UnityEvent onEndOverlay;
    public Animator overlayAnimator;

    private void Awake() {
        if(Instance == null) {
            Instance = this;
        }
        else {
            Destroy(this);
        }
    }
    public void StartOverlay() {
        overlayAnimator.SetBool("Overlay", true);
    }

    public void EndOverlay() {
        onEndOverlay?.Invoke();
        overlayAnimator.SetBool("Overlay", false);
    }
}
