using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class InteractEventActivator : EventActivator {
  private float contactOffset = 0.0f;

  private void Awake() {
    contactOffset = GetComponent<BoxCollider>().size.z * 0.5f * this.transform.localScale.z;
  }
  /// waits for the player to move to destination to activate event
  protected override void HoldInteract() {
    if (onHoldInteract != null)
      PlayerController.Instance.RequestMove(this.transform.position + this.transform.forward * contactOffset, onHoldInteract.Invoke);
  }
  /// waits for the player to move to destination to activate event
  protected override void Interact() {
    if (onInteract != null)
      PlayerController.Instance.RequestMove(this.transform.position + this.transform.forward * contactOffset, onInteract.Invoke);   
  }
}
