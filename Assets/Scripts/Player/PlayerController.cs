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
  Move(TargetDest, null);
}

public void RequestMove(Vector3 TargetDest, UnityEvent CallBack) {
  Move(TargetDest, CallBack);
}

private void Move(Vector3 TargetDest, UnityEvent CallBack) {
    navMeshAgent.SetDestination(TargetDest);
    if(CallBack != null) {
      StartCoroutine(Reached(CallBack));
  }
}

private IEnumerator Reached(UnityEvent CallBack) {
 if (!navMeshAgent.pathPending) {
     if (navMeshAgent.remainingDistance <= navMeshAgent.stoppingDistance) {
         if (!navMeshAgent.hasPath || navMeshAgent.velocity.sqrMagnitude == 0f) {
             CallBack.Invoke();
         }
      }
      yield return null;
    }
  }
}
