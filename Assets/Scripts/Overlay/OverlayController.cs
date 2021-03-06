﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class OverlayController : MonoBehaviour {

	public static OverlayController Instance;
	public UnityEvent onEndOverlay;
	public UnityEvent onStartOverlay;
	[SerializeField]
	private Animator overlayAnimator;

	private void Awake() {
		if(Instance == null) {
			Instance = this;
		} else {
			Destroy(this);
		}
	}

	/// Start obscuring the screen.
	public void StartOverlay() {
		onStartOverlay?.Invoke();
		overlayAnimator.SetBool("Overlay", true);
	}

	/// Start removing the overlay.
	public void EndOverlay() {
		onEndOverlay?.Invoke();
		overlayAnimator.SetBool("Overlay", false);
	}
}
