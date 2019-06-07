using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RemoteSound : MonoBehaviour {

	public void Play(string soundName) {
		SoundController.Instance.PlaySound(soundName);
	}
}
