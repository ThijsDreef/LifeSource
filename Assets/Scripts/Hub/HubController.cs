using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HubController : MonoBehaviour {
    public List<GameObject> levelHub = new List<GameObject>();


    private void Awake() { 
        SpawnLevelHubs();
    }  

    /// Generates the level hubs in a circle.
    private void SpawnLevelHubs() {
        print(LevelHandler.Instance.levelCount);
        for(int i = 0; i < LevelHandler.Instance.levelCount; i++) {
            GameObject copy = Instantiate(levelHub[i], new Vector3(Mathf.Cos(Mathf.Deg2Rad * 360 * ((float)i / LevelHandler.Instance.levelCount)) * 40, 15, Mathf.Sin(Mathf.Deg2Rad * 360 * ((float)i / LevelHandler.Instance.levelCount)) * 40), Quaternion.identity);
            copy.transform.parent = this.transform;     
        }
    }
}
