using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationController : MonoBehaviour {
  [SerializeField]
  private Animator animator;

  private void Start() {
    PlayerController.Instance.RequestStartCallback(PlayerControllerState.IDLE, IdleAnim);
    PlayerController.Instance.RequestStartCallback(PlayerControllerState.WALKING, WalkAnim);
  }

  private void IdleAnim() {
    animator.SetBool("Walking", false);
    animator.SetBool("Idle", true);
  }

  private void WalkAnim() {
    animator.SetBool("Walking", true);
    animator.SetBool("Idle", false);
  }
}
