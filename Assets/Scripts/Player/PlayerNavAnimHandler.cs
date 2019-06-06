using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PlayerNavAnimHandler : StateMachineBehaviour {
	private NavMeshAgent navMeshAgent;
	private ThirdPersonCharacter thirdPersonCharacter;
	private PlayerController playerController;

	override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
		if(!navMeshAgent) navMeshAgent = animator.gameObject.GetComponent<NavMeshAgent>();

		if(stateInfo.IsName("RotationBegin") || stateInfo.IsName("Shrine_Anim") || stateInfo.IsName("Character_Fly_land_Anim") || stateInfo.IsName("Character_Fly_up_Anim")) {
			navMeshAgent.enabled = false;
		}

		if(stateInfo.IsName("Locomotion")){
			navMeshAgent.enabled = true;
		}
	}

	override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
		if(!navMeshAgent) navMeshAgent = animator.gameObject.GetComponent<NavMeshAgent>();
		if(stateInfo.IsName("Fly_landing_fix_Anim")){
			PlayerController.Instance.WarpPlayer(PlayerController.Instance.currentSpawnPoint.transform.position);
		}

		if(stateInfo.IsName("Reflector_Release_Anim") || stateInfo.IsName("Shrine_Anim") || stateInfo.IsName("Fly_landing_fix_Anim")){
			navMeshAgent.enabled = true;
		}  
	}
}
