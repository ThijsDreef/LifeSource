using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GemRotateInteract : RotateInteractor {
  [SerializeField]
  private Transform startAnimationPosition;

  protected override IEnumerator Interacting() {
    PlayerController.Instance.RequestLookAt(this.transform);
    int deltaFactor = 300;
    float old = Input.acceleration.x * deltaFactor; 
    while (true) {
      this.transform.Rotate(new Vector3(0, 20 * Time.deltaTime, 0));
      yield return null;
      
    }
  }
}
