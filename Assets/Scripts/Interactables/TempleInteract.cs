using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TempleInteract : EventActivator {
  private Stack<TemplePieceType> piecesToAdd = new Stack<TemplePieceType>();
  [SerializeField]
  private Transform[] props = new Transform[3];
  private float contactOffset = 0.0f;

  private void Awake() {
    contactOffset = GetComponent<BoxCollider>().size.z * this.transform.localScale.z * 0.5f;
  }

  /// requests the player to move towards this gameobject and when it reaches it requests touch
  protected override void HoldInteract() {
    base.HoldInteract();
    PlayerController.Instance.RequestMove(this.transform.position + this.transform.forward * contactOffset, this.RequestTouch);
  }
  /// requests the player to move towards this gameobject and when it reaches it requests touch
  protected override void Interact() {
    base.Interact();
    PlayerController.Instance.RequestMove(this.transform.position + this.transform.forward * contactOffset, this.RequestTouch);
  }
  /// starts the new level if the required count is lower or equall to 0
  private void RequestTouch() {
    // TODO: should start next level here
    TemplePieceType piece = piecesToAdd.Pop();
    while (piece != TemplePieceType.UNDEFINED) {
      props[((int)piece) - 1].gameObject.SetActive(true);
      piece = piecesToAdd.Pop();
    }
  }

  public void EnqueueTemplePiece(TemplePieceType piece) {
    piecesToAdd.Push(piece);
  }
}