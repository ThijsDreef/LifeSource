using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class EventActivator : Interactable {
  [SerializeField]
  private UnityEvent onInteract;
  [SerializeField]
  private UnityEvent onHoldInteract;
  [SerializeField]
  private UnityEvent onBeamInteract;
  /// calls the onBeamInteract callback
  protected override void BeamInteract() {
    onBeamInteract?.Invoke();
  }
  /// calls the onHoldInteract callback
  protected override void HoldInteract() {
    onHoldInteract?.Invoke();
  }
  /// calls the onInteract callback
  protected override void Interact() {
    onInteract?.Invoke();
  }
}
