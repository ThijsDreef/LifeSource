using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class EventActivator : Interactable {
  [SerializeField]
  protected UnityEvent onInteract;
  [SerializeField]
  protected UnityEvent onHoldInteract;
  [SerializeField]
  protected UnityEvent onBeamInteract;
  [SerializeField]
  protected UnityEvent onBeamHoldInteract;
  /// calls the onBeamInteract callback
  protected override void BeamInteract() {
    onBeamInteract?.Invoke();
  }
  ///
  protected override void BeamHoldInteract() {
    onBeamHoldInteract?.Invoke();
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
