using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WalkInteractable : Interactable {
  /// BeamInteract is a empty function becuase we dont want to walk somewhere when the object is hit with a beam 
  protected override void BeamInteract() { }
  
  /// HoldInteract is used to request the PlayerController to move towards the touched point
  protected override void HoldInteract() {
    // PlayerController.Instance.RequestMove(Camera.main.ScreenToWorldPoint(Input.mousePosition));
  }

  /// Interact is used to request the PlayerController to move towards the touched point
  protected override void Interact() {
    Vector3 mousePos = Input.mousePosition;
    mousePos.z = 10;
    PlayerController.Instance.RequestMove(Camera.main.ScreenToWorldPoint(mousePos));
  }
}
