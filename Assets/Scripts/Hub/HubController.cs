using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HubController : MonoBehaviour {
    public List<GameObject> levelHub = new List<GameObject>();

    private void Awake() { 
        for(int i = 0; i < LevelHandler.Instance.levels.Count; i++) {
            GameObject copy = Instantiate(levelHub[i], new Vector3(Mathf.Cos(Mathf.Deg2Rad * 360 * ((float)i / LevelHandler.Instance.levels.Count)) * 40, 15, Mathf.Sin(Mathf.Deg2Rad * 360 * ((float)i / LevelHandler.Instance.levels.Count)) * 40), Quaternion.identity);
            copy.transform.parent = this.transform;     
        }
    }  
}
