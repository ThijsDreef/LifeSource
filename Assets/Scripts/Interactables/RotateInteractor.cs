using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateInteractor : Interactable {
  private Coroutine interactCoroutine;

  /// should get a VFX effect on BeamInteract
  protected override void BeamInteract() { }

  protected override void HoldInteract() {
    PlayerController.Instance.RequestMove(this.transform.position, this.RequestRotate);
  }

  protected override void Interact() {
    PlayerController.Instance.RequestMove(this.transform.position, this.RequestRotate);
  }

  private void RequestRotate() {
    PlayerController.Instance.RequestInteract(this);
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
  protected virtual IEnumerator Interacting() {
    while (true) {
      yield return null;
    }
  }
}