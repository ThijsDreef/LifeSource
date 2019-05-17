using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TempleInteract : Interactable {

  /// is not implemented yet could be used to start a VFX
  protected override void BeamInteract() { }

  /// requests the player to move towards this gameobject and when it reaches it requests touch
  protected override void HoldInteract() {
    // PlayerController.Instance.RequestMove(this.transform.position, this.RequestTouch);
  }
  /// requests the player to move towards this gameobject and when it reaches it requests touch
  protected override void Interact() {
    // PlayerController.Instance.RequestMove(this.transform.position, this.RequestTouch);
  }
  /// starts the new level if the required count is lower or equall to 0
  private void RequestTouch() {
    // TODO: should start next level here
  }
}