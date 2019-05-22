using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateInteractor : EventActivator {
  private Coroutine interactCoroutine;
  private float contactOffset = 0.0f;

  private void Awake() {
  
    contactOffset = GetComponent<BoxCollider>().size.z * this.transform.localScale.z * 0.5f;
    Debug.LogError(contactOffset);
  }
  private void MoveToInteract() {
		ParticleContainer.Instance.EmitInteractParticle(this.transform.position + this.transform.forward * contactOffset);
    PlayerController.Instance.RequestMove(this.transform.position + this.transform.forward * contactOffset, this.RequestRotate);
  }

  protected override void HoldInteract() {
    base.HoldInteract();
    MoveToInteract();
  }

  protected override void Interact() {
    base.Interact();
    MoveToInteract();
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
    ParticleContainer.Instance.StopEmitInteractParticle();
  }

  /// should be overwritten to implement some interact functionality over multiple frames
  protected virtual IEnumerator Interacting() {
    while (true) {
      yield return null;
    }
  }
}