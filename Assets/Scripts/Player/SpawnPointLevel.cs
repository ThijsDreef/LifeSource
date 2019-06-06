using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPointLevel : MonoBehaviour {
    public Transform spawnPoint;
    [SerializeField]
    private bool Landing;
    [SerializeField]
    private Transform landingSpawnPoint;
    /// Start warp the player to the spawn point.
    [SerializeField]
    private float CorrectStartRotation;
    private void OnEnable() {
         PlayerController.Instance.SetCurrentSpawnPoint(spawnPoint.gameObject);
        if(Landing) {
            PlayerController.Instance.WarpPlayer(landingSpawnPoint.position);
            PlayerController.Instance.transform.rotation = transform.parent.rotation;
            PlayerController.Instance.RequestPlayerLand(null);
        }
        else {
            PlayerController.Instance.WarpPlayer(PlayerController.Instance.currentSpawnPoint.transform.position);   
        }
    }
}
