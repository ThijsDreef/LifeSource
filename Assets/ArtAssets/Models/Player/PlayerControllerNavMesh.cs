using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class PlayerControllerNavMesh : MonoBehaviour {
    public Camera camera;
    public NavMeshAgent agent;
    [SerializeField]
    ThirdPersonCharacter character;

    private void Start() {
        camera = Camera.main;
        agent = GetComponent<NavMeshAgent>();
        agent.updateRotation = false;
        character = GetComponent<ThirdPersonCharacter>();
    }
    void Update() {
        if(Input.GetMouseButtonDown(0)) {
            Ray ray = camera.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if(Physics.Raycast(ray, out hit)) {
                agent.SetDestination(hit.point);
            }
        }

        if(agent.remainingDistance > agent.stoppingDistance) {
        character.Move(agent.desiredVelocity, false, false);
        } else {
            character.Move(Vector3.zero, false ,false);
        }
    }
}
