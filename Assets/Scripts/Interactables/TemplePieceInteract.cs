using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public enum TemplePieceType {
  UNDEFINED,
  LEFT_HORN,
  RIGHT_HORN,
  NOSE_RING
};

public class TemplePieceInteract : EventActivator {

  [SerializeField]
  private UnityEvent onPickUp;

  [SerializeField]
  private TempleInteract temple;
  [SerializeField]
  private float destroyDelay = 0;
  [SerializeField]
  private TemplePieceType type;
  public TemplePieceType Type {get {return type;} }

  private float contactOffset = 0.0f;

  private void Awake() {
    // contactOffset = GetComponent<BoxCollider>().size.z * this.transform.localScale.z * 0.5f;
  }

  /// requests pickup of the collectable
  protected override void HoldInteract() {
    base.HoldInteract();
    RequestPickUp();
  }
  /// requests pickup of the collectable
  protected override void Interact() {
    base.Interact();
    RequestPickUp();
  }

  /// requests player to move towards this gameobject and execute OnPickUp at arrival
  private void RequestPickUp() {
    PlayerController.Instance.RequestMove(this.transform.position + this.transform.forward * contactOffset, this.OnPickUp);
  }

  /// destroys this object and decrements the counter
  private void OnPickUp() {
    onPickUp?.Invoke();
    RelicsCollected.Instance.CollectPiece(Type);
    if (temple) temple.EnqueueTemplePiece(Type);
    Destroy(this.gameObject, destroyDelay);
  }
}
