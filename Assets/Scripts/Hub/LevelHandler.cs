using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelHandler : MonoBehaviour {
  public static LevelHandler Instance;
  [SerializeField]
  private int levelCount;
  private List<int> unlockedLevels = new List<int>();
  private int currentLevelIndex;
  private AsyncOperation loadScene;
  [SerializeField]
  private int[] defaultUnlockedLevels = new int[1];

  [SerializeField]
  private int defaultStartLevel = 0;
    

  private void Start() {
    if(Instance == null) {
      Instance = this;
    } else {
      Destroy(this);
      return;
    }

    for(int i = 0; i < levelCount; i++) unlockedLevels.Add(PlayerPrefs.GetInt("UnlockState" + i));
    for (int i = 0; i < defaultUnlockedLevels.Length; i++) unlockedLevels[defaultUnlockedLevels[i]] = defaultUnlockedLevels[i];

    ChangeLevel(defaultStartLevel);
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
    loadScene.allowSceneActivation = true;
    OverlayController.Instance.onEndOverlay.RemoveListener(SetupLevel);
  }

  /// Unlocks level which can then be played.
  public void UnlockLevel(int unlockIndex) {
    if(!unlockedLevels.Contains(unlockIndex)) {
      unlockedLevels.Add(unlockIndex);
      PlayerPrefs.SetInt("UnlockState" + unlockIndex, unlockIndex);
    }
  }

  public bool IsLevelUnlocked(int level) {
    return unlockedLevels.Contains(level);
  }
}
