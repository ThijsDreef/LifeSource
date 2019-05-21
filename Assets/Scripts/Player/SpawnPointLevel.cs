using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPointLevel : MonoBehaviour
{
    public Transform spawnPoint;

    /// Start warp the player to the spawn point.
    private void OnEnable() {
        PlayerController.Instance.WarpPlayer(spawnPoint.position);
    }
}
