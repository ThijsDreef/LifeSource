using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelHandler : MonoBehaviour {

    public static LevelHandler Instance;
    public List<GameObject> levels = new List<GameObject>();
    public List<int> unlockedLevels = new List<int>();

    private void Awake() {

        if(Instance == null) {
            Instance = this;
        }
        else {
            Destroy(this);
        }

        for(int i = 0; i < levels.Count; i++) {
            unlockedLevels.Add(PlayerPrefs.GetInt("UnlockState" + i));
        }
    }

    public void ChangeLevel(int levelIndex) {
        if(unlockedLevels.Contains(levelIndex)) {
            for(int i = 0; i < levels.Count; i++) {
                levels[i].SetActive(false);
            }
            levels[levelIndex].SetActive(true);
        }
    }

    public void UnlockLevel(int unlockIndex) {
        if(!unlockedLevels.Contains(unlockIndex)) {
            unlockedLevels[unlockIndex] = unlockIndex;
            PlayerPrefs.SetInt("UnlockState" + unlockIndex, unlockIndex);
        }
    }
}
