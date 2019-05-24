﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using System;


public class PlayerController : MonoBehaviour {
  public static PlayerController Instance = null;
  private Vector3 sampledPosition;
  [SerializeField]
  private NavMeshAgent navMeshAgent;
  [SerializeField]
  private PlayerControllerState currentPlayerState = PlayerControllerState.IDLE;
  private OnStateAction[] actions = new OnStateAction[(int)PlayerControllerState.LENGTH];
  private bool TargetReached;
  private Coroutine currentRoutine = null;
  private Interactable interactable;
  ThirdPersonCharacter character;

  private void Awake() {
    if (Instance == null) {
      Instance = this;
    }
    else if (Instance != this) {
      Destroy(gameObject);
    }
  }

  private void Start() {
    character = GetComponent<ThirdPersonCharacter>();
    navMeshAgent = this.GetComponent<NavMeshAgent>();
    navMeshAgent.updateRotation = false;
    actions[(int)PlayerControllerState.INTERACTING].onEnd += StopInteract;
  }

  private void Update() {
    if(navMeshAgent.hasPath){
      if(TargetReached || navMeshAgent.remainingDistance <= navMeshAgent.stoppingDistance){
        character.Move(Vector3.zero, false ,false);
     }
    }
  }

  /// Function to set a new destination for the navMesh player movement, with callback.
  public void RequestMove(Vector3 TargetDest, Action CallBack = null) {
    Move(TargetDest, CallBack);
  }
  
  public void RequestLookAt(Transform target, Action callback = null){
    PlayerLookAt(target, callback);
  }

  private void PlayerLookAt(Transform target, Action callback = null){
      Vector3 lookDirection = target.position;
      lookDirection.y = transform.position.y;
      transform.LookAt(lookDirection);
  }

  /// RequestStartCallBack is used to add functionality on start.
  public void RequestStartCallback(PlayerControllerState state, Action callback) {
    actions[(int)state].onStart += callback;
  }

  /// Request interact function to add interacts.
  public void RequestInteract(Interactable interactObject) {
    interactObject.StartInteract();
    interactable = interactObject;
    SetState(PlayerControllerState.INTERACTING);
  }

  public void RequestReflectorRotation(){
    //navMeshAgent.enabled = false;
    character.ReflectorRotationEnabled();
  }

  public void RequestStopReflectorRotation(){
    character.ReflectorRotationDisabled();
    //navMeshAgent.enabled = true;
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
    NavMeshHit hit;
    if (!NavMesh.SamplePosition(TargetDest, out hit, 10.0f, NavMesh.AllAreas)) {
      Debug.LogError("could not reach destination");
      return;
    }
    sampledPosition = TargetDest;
    navMeshAgent.isStopped = false;
    SetState(PlayerControllerState.WALKING);
    navMeshAgent.SetDestination(hit.position);
    if (currentRoutine != null) StopCoroutine(currentRoutine);
    currentRoutine = StartCoroutine(Reached(CallBack));
  }

  private IEnumerator Reached(Action CallBack) {
    TargetReached = false;
    do {
      if (navMeshAgent.pathPending) {
        yield return null;
        continue;
      }
      if (navMeshAgent.remainingDistance > navMeshAgent.stoppingDistance) {
        character.Move(navMeshAgent.desiredVelocity, false, false);
        yield return null;
        continue;
      }
      if (!navMeshAgent.hasPath) {
        yield return null;
        SetState(PlayerControllerState.IDLE);
        break;
      }
      else {
        TargetReached = true;
      }
    } while (!TargetReached);
    SetState(PlayerControllerState.IDLE);
    navMeshAgent.isStopped = true;
    if (TargetReached && Vector3.Distance(sampledPosition, this.transform.position) < 10.0) CallBack?.Invoke();
  } 

  /// Warp the player to the given position.
  public void WarpPlayer(Vector3 position) {
    navMeshAgent.Warp(position);
  }
}
