using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GemRotateInteract : RotateInteractor {

  private void Start() {
    // StartCoroutine(Interacting());
  }
  protected override IEnumerator Interacting() {
    while (true) {
      this.transform.Rotate(new Vector3(0, Input.gyro.rotationRate[1] * 200 + 0.2f, 0));
      yield return null;
    }
  }
}
