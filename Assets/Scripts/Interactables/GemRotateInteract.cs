using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GemRotateInteract : RotateInteractor {
  protected override IEnumerator Interacting() {
    int deltaFactor = 300;
    float old = Input.acceleration.x * deltaFactor; 
    while (true) {
     // this.transform.Rotate(new Vector3(0, 0.5f, 0));
      yield return null;
    }
  }
}
