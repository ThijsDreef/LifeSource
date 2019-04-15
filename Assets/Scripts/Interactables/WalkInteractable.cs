using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WalkInteractable : Interactable {
  /// BeamInteract is a empty function becuase we dont want to walk somewhere when the object is hit with a beam 
  protected override void BeamInteract() { }
  [SerializeField]
  private GameObject helpObj;
  /// HoldInteract is used to request the PlayerController to move towards the touched point
  protected override void HoldInteract() {
    // PlayerController.Instance.RequestMove(Camera.main.ScreenToWorldPoint(Input.mousePosition));
  }

  /// Interact is used to request the PlayerController to move towards the touched point
  protected override void Interact() {
    RaycastHit hit;
    Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
    if(Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hit, 100)){
      PlayerController.Instance.RequestMove(hit.point);
      Debug.DrawLine(ray.origin, ray.direction * 10000, Color.red);
      helpObj.transform.position = hit.point;
    }
    /*
    Vector3 mousePos = Input.mousePosition;
    mousePos.z = Camera.main.nearClipPlane;
    helpObj.transform.position =  Camera.main.ScreenToWorldPoint(mousePos);
    PlayerController.Instance.RequestMove(Camera.main.ScreenToWorldPoint(mousePos));
    */
  }
}
