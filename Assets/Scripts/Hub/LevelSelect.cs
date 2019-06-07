using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelSelect : MonoBehaviour {
	public int levelIndex;
	private void Start() {
		if (!LevelHandler.Instance.IsLevelUnlocked(levelIndex)) this.gameObject.SetActive(false);
	}
	/// Select the level with the given index.
	public void Select() {
		LevelHandler.Instance.ChangeLevel(levelIndex);
	}

	public void PlayerExitLevelSelect() {
		PlayerController.Instance.RequestPlayerFlyUp(null);
		StartCoroutine(DelayedSelect());
	}

	private IEnumerator DelayedSelect() {
		yield return new WaitForSeconds(1.7f);
		Select();
		StopCoroutine(DelayedSelect());
	}
}
