using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Events;


[RequireComponent(typeof(NavMeshAgent))]
public class PlayerController : MonoBehaviour {
public static PlayerController Instance = null;
[SerializeField]
private NavMeshAgent navMeshAgent;
private bool TargetReached;
private void Awake(){
    if(Instance == null){
      Instance = this;
    }
    else if(Instance != this){
      Destroy(gameObject);
    }
}

private void Start() {
  navMeshAgent = this.GetComponent<NavMeshAgent>();
}

public void RequestMove(Vector3 TargetDest) {
  Debug.Log("Test");
  Move(TargetDest, null);
}

public void RequestMove(Vector3 TargetDest, UnityEvent CallBack) {
  Debug.Log(TargetDest);
  Move(TargetDest, CallBack);
}

private void Move(Vector3 TargetDest, UnityEvent CallBack) {
    navMeshAgent.SetDestination(TargetDest);
    StartCoroutine(Reached(CallBack));
}

private IEnumerator Reached(UnityEvent CallBack) {
  TargetReached = false;
   do{
  	if (navMeshAgent.pathPending) {
      Debug.Log("Path is still calculated");
      yield return null;
    }
    if(navMeshAgent.remainingDistance >= navMeshAgent.stoppingDistance){
        Debug.Log("Path ready but not yet on destination");
        yield return null;
    }
    if (navMeshAgent.hasPath) {
      yield return null;
    }
    else {
      TargetReached = true;
    }
   }while(!TargetReached);
    Debug.Log("Reached");
    CallBack?.Invoke();
  }
}
