using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Interactable : MonoBehaviour {
  public static int Counter = 0;
  [SerializeField]
  private float holdInteractionTime = 1.0f;
  private float beamHoldInteractionTime = 1.0f;
  private float currentHoldInteractionTime;
  private float currentBeamHoldInteractiontime;
  private bool currentBeamNotify = false;

  /// this gets called when the GameObject gets tapped on
  protected abstract void Interact();
  /// this gets called when the GameObject gets hold On
  protected abstract void HoldInteract();
  /// this gets called when the GameObject is interacted with a beam
  protected abstract void BeamInteract();

  protected abstract void BeamHoldInteract();

  /// a optional callback to start some interaction wich does work over multiple frames
  public virtual void StartInteract() { }
  /// a optional callback to stop some interaction wich did work over multiple frames
  public virtual void StopInteract() { }

  private void OnMouseDown() {
    Counter++;
    Interact();
  }

  private void OnMouseUp() {
    currentHoldInteractionTime = 0;
  }


  private void OnMouseDrag() {
    currentHoldInteractionTime += Time.deltaTime;
    if (holdInteractionTime > currentHoldInteractionTime) {
      HoldInteract();
      currentHoldInteractionTime = 0;
    }
  }
  /// this gets called when hit by a BeamInteractor please dont call this function from anywhere else
  public void OnBeamHit() {
    if (currentBeamHoldInteractiontime <= 0.0f && !currentBeamNotify) {
      BeamInteract();
    }
    currentBeamHoldInteractiontime += Time.deltaTime;
    if (currentBeamHoldInteractiontime > beamHoldInteractionTime && !currentBeamNotify) {
      BeamHoldInteract();
      currentBeamNotify = true;
    }
  }

  public void OnBeamExit() {
    currentBeamHoldInteractiontime = 0.0f;
    currentBeamNotify = false;
  }

}
