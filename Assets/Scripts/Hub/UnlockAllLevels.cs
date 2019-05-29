using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnlockAllLevels : MonoBehaviour {
  [SerializeField]
  private int maxLevels = 0;
  
  public void unlockLevels() {
    for (int i = 0; i < maxLevels; i++) {
      LevelHandler.Instance.UnlockLevel(i);
    }
  }
}