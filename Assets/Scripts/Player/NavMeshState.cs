using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class NavMeshState : StateMachineBehaviour {
    [SerializeField]
    private NavMeshAgent navMeshAgent;
    [SerializeField]
    private bool DisableNavMesh;

    // OnStateEnter is called before OnStateEnter is called on any state inside this state machine
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
        if(stateInfo.IsName("RotationBegin")){
            if(navMeshAgent == null){
                navMeshAgent = PlayerController.Instance.GetComponent<NavMeshAgent>();
            }
           navMeshAgent.enabled = false;
           DisableNavMesh = true;
        }
    }
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
    if(stateInfo.IsName("Reflector_Release_Anim")){
            if(navMeshAgent == null){
                navMeshAgent = PlayerController.Instance.GetComponent<NavMeshAgent>();
            }
           navMeshAgent.enabled = true;
           DisableNavMesh = false;
        }   
    }
}
