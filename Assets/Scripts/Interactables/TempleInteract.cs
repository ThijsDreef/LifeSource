using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TempleInteract : EventActivator {
  [SerializeField]
  private int levelToStart = 2;
  [SerializeField]
  private int levelToUnlock = 2;
  private Stack<TemplePieceType> piecesToAdd = new Stack<TemplePieceType>();
  [SerializeField]
  private Transform[] props = new Transform[3];
  private float contactOffset = 0.0f;

  private void Awake() {
    // contactOffset = GetComponent<BoxCollider>().size.z * this.transform.localScale.z * 0.5f;
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
    if (piecesToAdd.Count != 3) return;
    // TODO: should start next level here
    while (piecesToAdd.Count > 0) {
      props[((int)piecesToAdd.Pop()) - 1].gameObject.SetActive(true);
    }
    LevelHandler.Instance.UnlockLevel(levelToUnlock);
    LevelHandler.Instance.ChangeLevel(levelToStart);
  }

  public void EnqueueTemplePiece(TemplePieceType piece) {
    piecesToAdd.Push(piece);
  }
}