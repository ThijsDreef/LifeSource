using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelSelect : MonoBehaviour
{
    public int levelIndex;

    /// Select the level with the given index.
    public void Select() {
        LevelHandler.Instance.ChangeLevel(levelIndex);
    }
}
