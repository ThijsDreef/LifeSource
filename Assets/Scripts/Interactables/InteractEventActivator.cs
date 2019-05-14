using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class InteractEventActivator : EventActivator {
  /// waits for the player to move to destination to activate event
  protected override void HoldInteract() {
    if (onHoldInteract != null)
      PlayerController.Instance.RequestMove(this.transform.position, onHoldInteract.Invoke);
  }
  /// waits for the player to move to destination to activate event
  protected override void Interact() {
    if (onInteract != null)
      PlayerController.Instance.RequestMove(this.transform.position, onInteract.Invoke);   
  }
}
