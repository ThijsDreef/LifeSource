using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

[RequireComponent(typeof(Text))]
public class InteractableCounter : MonoBehaviour {
  private Text text;

  private void Start() {
    text = GetComponent<Text>();
    OverlayController.Instance.onEndOverlay.AddListener(this.Reset);
  }
  
  private void Update() {
    text.text = Interactable.Counter.ToString();
  }
  private void Reset() {
    Interactable.Counter = 0;
  }
}
