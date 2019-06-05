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
    private void OnEnable() {
        if(Landing) {
            PlayerController.Instance.WarpPlayer(landingSpawnPoint.position);
            PlayerController.Instance.transform.eulerAngles = new Vector3(0,180,0);
            PlayerController.Instance.RequestPlayerLand(null);
        }
        else {
            PlayerController.Instance.WarpPlayer(spawnPoint.position);   
        }
    }
}
