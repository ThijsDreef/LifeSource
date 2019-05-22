using System.Collections;
using System.Collections.Generic;
using UnityEngine;
  
public class WalkInteractable : EventActivator {
  /// HoldInteract is used to request the PlayerController to move towards the touched point
  protected override void HoldInteract() {
    base.HoldInteract();
    Interact();
  }

  /// Interact is used to request the PlayerController to move towards the touched point
  protected override void Interact() {
    base.Interact();
    RaycastHit hit;
    #if (UNITY_IPHONE || UNITY_ANDROID) && !UNITY_EDITOR 
      Ray ray = Camera.main.ScreenPointToRay(Input.touches[0].position);
    #else 
      Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
    #endif
    if(Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hit, 500)) PlayerController.Instance.RequestMove(hit.point);
    ParticleContainer.Instance.EmitWalkParticle(hit.point);
  }
}
