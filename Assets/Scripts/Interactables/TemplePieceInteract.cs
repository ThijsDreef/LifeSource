using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TemplePieceInteract : Interactable {
  [SerializeField] 
  TempleInteract temple = null;
  [SerializeField]
  float destroyDelay = 0;
  /// could be used to start some form of VFX 
  protected override void BeamInteract() { }
  /// requests pickup of the collectable
  protected override void HoldInteract() {
    RequestPickUp();
  }
  /// requests pickup of the collectable
  protected override void Interact() {
    RequestPickUp();
  }

  /// requests player to move towards this gameobject and execute OnPickUp at arrival
  private void RequestPickUp() {
    PlayerController.Instance.RequestMove(this.transform.position, this.OnPickUp);
  }

  /// destroys this object and decrements the counter 
  private void OnPickUp() {
    if (temple != null) temple.addPiece();
    Destroy(this.gameObject, destroyDelay);
  }
}