using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Interactable : MonoBehaviour {
  [SerializeField]
  private float holdInteractionTime = 1.0f;
  private float currentHoldInteractionTime;

  /// this gets called when the GameObject gets tapped on
  protected abstract void Interact();
  /// this gets called when the GameObject gets hold On
  protected abstract void HoldInteract();
  /// this gets called when the GameObject is interacted with a beam
  protected abstract void BeamInteract();

  /// a optional callback to start some interaction wich does work over multiple frames
  public virtual void StartInteract() { }
  /// a optional callback to stop some interaction wich did work over multiple frames
  public virtual void StopInteract() { }

  private void OnMouseDown() {
    Interact();
    currentHoldInteractionTime = 0;
  }

  private void OnMouseDrag() {
    currentHoldInteractionTime += Time.deltaTime;
    if (holdInteractionTime < currentHoldInteractionTime) {
      HoldInteract();
      currentHoldInteractionTime = 0;
    }
  }
  /// this gets called when hit by a BeamInteractor please dont call this function from anywhere else
  public void OnBeamHit() {
    BeamInteract();
  }

}
