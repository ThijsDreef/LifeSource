using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateInteractor : Interactable {
  private Coroutine interactCoroutine;

  /// should get a VFX effect on BeamInteract
  protected override void BeamInteract() { }

  protected override void HoldInteract() {
    // PlayerController.RequestMove(this.transform.position, this.RequestRotate);
  }

  protected override void Interact() {
    // PlayerController.RequestMove(this.transform.position, this.RequestRotate);
  }

  private void RequestRotate() {
    // PlayerController.RequestInteract(this);
  }

  /// starts interacting coroutine
  public override void StartInteract() {
    interactCoroutine = StartCoroutine(Interacting());
  }

  /// stops interacting coroutine
  public override void StopInteract() {
    StopCoroutine(interactCoroutine);
  }

  /// should be overwritten to implement some interact functionality over multiple frames
  public virtual IEnumerator Interacting() {
    while (true) {
      yield return null;
    }
  }
}