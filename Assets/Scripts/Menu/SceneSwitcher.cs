using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneSwitcher : MonoBehaviour {

	/// Loads the given scene.
	public void LoadScene(int sceneIndex) {
		print(SceneManager.sceneCount);
		if(sceneIndex <= SceneManager.sceneCount) SceneManager.LoadScene(sceneIndex);
	}

	/// Stops the aplication.
	public void Quit(){
		Application.Quit();
	}
}
