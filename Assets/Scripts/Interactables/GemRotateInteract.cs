using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GemRotateInteract : RotateInteractor {

  private void Start() {
    // StartCoroutine(Interacting());
  }
  protected override IEnumerator Interacting() {
    int deltaFactor = 300;
    float old = Input.acceleration.x * deltaFactor; 
    while (true) {
      this.transform.Rotate(new Vector3(0, (Input.acceleration.x * deltaFactor) - old, 0));
      old = Input.acceleration.x * deltaFactor;
      yield return null;
    }
  }
}
