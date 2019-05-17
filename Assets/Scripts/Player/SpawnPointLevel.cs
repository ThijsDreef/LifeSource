using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPointLevel : MonoBehaviour
{
    public Transform spawnPoint;

    private void OnEnable() {
        PlayerController.Instance.WarpPlayer(spawnPoint.position);
    }
}
