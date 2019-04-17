using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using System;


[RequireComponent(typeof(NavMeshAgent))]
public class PlayerController : MonoBehaviour {
  public static PlayerController Instance = null;
  [SerializeField]
  private NavMeshAgent navMeshAgent;
  [SerializeField]
  private PlayerControllerState currentPlayerState = PlayerControllerState.IDLE;
  private OnStateAction[] actions = new OnStateAction[(int)PlayerControllerState.LENGTH];
  private bool TargetReached;
  private Coroutine currentRoutine = null;
  private Interactable interactable;

  private void Awake() {
    if (Instance == null) {
      Instance = this;
    }
    else if (Instance != this) {
      Destroy(gameObject);
    }
  }

  private void Start() {
    navMeshAgent = this.GetComponent<NavMeshAgent>();
    actions[(int)PlayerControllerState.INTERACTING].onEnd += StopInteract;
  }

  public void RequestMove(Vector3 TargetDest) {
    Move(TargetDest, null);
  }

  public void RequestMove(Vector3 TargetDest, Action CallBack) {
    Move(TargetDest, CallBack);
  }

  public void RequestStartCallback(PlayerControllerState state, Action callback) {
    actions[(int)state].onStart += callback;
  }

  public void RequestInteract(Interactable interactObject) {
    interactObject.StartInteract();
    interactable = interactObject;
    SetState(PlayerControllerState.INTERACTING);
  }

  private void StopInteract() {
    interactable.StopInteract();
  }

  private void SetState(PlayerControllerState state) {
    actions[(int)currentPlayerState].onEnd?.Invoke();
    currentPlayerState = state;
    actions[(int)currentPlayerState].onStart?.Invoke();
  }

  private void Move(Vector3 TargetDest, Action CallBack) {
    SetState(PlayerControllerState.WALKING);
    navMeshAgent.SetDestination(TargetDest);
    if (currentRoutine != null) StopCoroutine(currentRoutine);
    currentRoutine = StartCoroutine(Reached(CallBack));
  }

  private IEnumerator Reached(Action CallBack) {
    TargetReached = false;
    do {
      if (navMeshAgent.pathPending) {
        yield return null;
      }
      if (navMeshAgent.remainingDistance >= navMeshAgent.stoppingDistance) {
        yield return null;
      }
      if (navMeshAgent.hasPath) {
        yield return null;
      }
      else {
        TargetReached = true;
      }
    } while (!TargetReached);
    SetState(PlayerControllerState.IDLE);
    CallBack?.Invoke();
  }
}
