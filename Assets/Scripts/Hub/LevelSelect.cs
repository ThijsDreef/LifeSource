using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelSelect : MonoBehaviour
{
    public int levelIndex;

    public void Select() {
        print(levelIndex);
        LevelHandler.Instance.ChangeLevel(levelIndex);
    }
}
