using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GemRotateInteract : RotateInteractor {
  private Quaternion Newrotation;
  Vector3 eulerAngles;
  [SerializeField]
  private Transform startAnimationPosition;
  private void Start() {
    // StartCoroutine(Interacting());
  }

  protected override IEnumerator Interacting() {
    //PlayerController.Instance.WarpPlayer(startAnimationPosition.transform.position);
    PlayerController.Instance.RequestLookAt(this.transform);
    int deltaFactor = 300;
    float old = Input.acceleration.x * deltaFactor; 
    while (true) {
      /* 
      transform.LookAt(PlayerController.Instance.transform);
      eulerAngles = transform.rotation.eulerAngles;
      eulerAngles.x = 0;
      eulerAngles.z = 0;
      transform.rotation = Quaternion.Euler(eulerAngles);
      */
      this.transform.Rotate(new Vector3(0, 0.5f, 0));
      yield return null;
      
    }
  }
}
