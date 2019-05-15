using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelHandler : MonoBehaviour {

    public static LevelHandler Instance;
    public int levelCount;
    public GameObject spawnPoint;
    private List<int> unlockedLevels = new List<int>();
    private int currentLevelIndex;
    private AsyncOperation loadScene;

    private void Start() {

        if(Instance == null) {
            Instance = this;
        }
        else {
            Destroy(this);
            return;
        }

        for(int i = 0; i < levelCount; i++) {
            unlockedLevels.Add(PlayerPrefs.GetInt("UnlockState" + i));
        }
        unlockedLevels[1] = 1;
        unlockedLevels[2] = 2;
        ChangeLevel(1);
    }

    /// Disable all levels and then enables the given level if it is unlockd.
    public void ChangeLevel(int levelIndex) {
        if(unlockedLevels.Contains(levelIndex) && currentLevelIndex != levelIndex) {
            OverlayController.Instance.onEndOverlay.AddListener(SetupLevel);
            OverlayController.Instance.StartOverlay();
            loadScene = SceneManager.LoadSceneAsync(levelIndex, LoadSceneMode.Additive);
            loadScene.allowSceneActivation = false;
            if(currentLevelIndex != 0) {
                SceneManager.UnloadSceneAsync(currentLevelIndex, UnloadSceneOptions.UnloadAllEmbeddedSceneObjects);
            }
            currentLevelIndex = levelIndex;
        }
    }

    /// Activates the scene and removes the overlay.
    private void SetupLevel() {
        spawnPoint.SetActive(false);
        loadScene.allowSceneActivation = true;
        OverlayController.Instance.onEndOverlay.RemoveListener(SetupLevel);
    }

    /// Unlocks level witch kan then be played.
    public void UnlockLevel(int unlockIndex) {
        if(!unlockedLevels.Contains(unlockIndex)) {
            unlockedLevels[unlockIndex] = unlockIndex;
            PlayerPrefs.SetInt("UnlockState" + unlockIndex, unlockIndex);
        }
    }
}
