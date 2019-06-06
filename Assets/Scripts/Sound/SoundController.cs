using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class SoundController : MonoBehaviour
{
    public AudioMixerGroup SFXMixer;
    public static SoundController Instance;
    public Sound[] SFX;
    private void Awake() {
        if (Instance != null) {
            Destroy(gameObject);
        } else {
            Instance = this;
        }
    }

    private void Start() {
        AudioSourcesCreator();
    }

    private void AudioSourcesCreator() {
        for (int i = 0; i < SFX.Length; i++) {
            GameObject _go = new GameObject("Sound_" + i + "_" + SFX[i].soundName);
            _go.transform.SetParent(this.transform);
            AudioSource audioSource = _go.AddComponent<AudioSource>();
            audioSource.outputAudioMixerGroup = SFXMixer;
            SFX[i].SetSource(audioSource);
        }
    }

    public void PlaySound(string _soundName) {
        for (int i = 0; i < SFX.Length; i++) {
            if (SFX[i].soundName == _soundName) {
                StartCoroutine(Delay(i, SFX[i].delay));
                return;
            }
        }
        //no sounds found
        Debug.LogWarning("AudioManager: Sound not found in list. " + _soundName);
    }

    private IEnumerator Delay(int index, float delayTime) {
        yield return new WaitForSeconds(delayTime);
        SFX[index].Play();
    }

    public void ToggleAudio(string type) {
        float volume;
        SFXMixer.audioMixer.GetFloat(type, out volume);
        if(volume == 0) {
            SFXMixer.audioMixer.SetFloat(type, -80);
        }
        else {
            SFXMixer.audioMixer.SetFloat(type, 0);
        }
        
    }
}
