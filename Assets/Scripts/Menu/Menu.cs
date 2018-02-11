using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Menu : MonoBehaviour {

	public PlayerData data;

	public GameObject basicPanel;
	public GameObject settingsPanel;

	public GameObject basicAudioToggle;
	public GameObject otherAudioToggle;

	public Slider basicAudio;
	public Slider otherAudio;

	private AudioSource audioOther;
	private AudioSource audioMelody;

	// Use this for initialization
	void Start () {
		if (PlayerPrefs.HasKey("fBasicMusic")) data.fBasicMusic = PlayerPrefs.GetFloat("fBasicMusic");
		else data.fBasicMusic = 0.3f;

		if (PlayerPrefs.HasKey("fOtherMusic")) data.fOtherMusic = PlayerPrefs.GetFloat("fOtherMusic");
		else data.fBasicMusic = 0.1f;

		audioMelody = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<AudioSource>();
		audioOther = GetComponent<AudioSource>();

		basicAudio.value = data.fBasicMusic;
		otherAudio.value = data.fOtherMusic;

		if ( data.fBasicMusic == 0) {
			audioMelody.Stop();
			basicAudioToggle.GetComponent<Toggle>().isOn = false;
		}
		if ( data.fOtherMusic == 0) otherAudioToggle.GetComponent<Toggle>().isOn = false; 


		audioOther.Stop();
	}
	
	// Update is called once per frame
	void LateUpdate () {
		if (Input.GetKeyDown(KeyCode.Escape) && settingsPanel.active) Back();
		AudioVolume();
	}

	public void AudioVolume() {
						
		// Если true то оставляем мелодию и настраиваем громкость.
		if (basicAudioToggle.GetComponent<Toggle>().isOn) {
			if (!audioMelody.isPlaying) audioMelody.Play();
			data.fBasicMusic = basicAudio.value;
			audioMelody.volume = data.fBasicMusic;
		}
		else {
			data.fBasicMusic = 0;
			audioMelody.Stop();
		}

		// Если true то оставляем звуки и настраиваем громкость.
		if (otherAudioToggle.GetComponent<Toggle>().isOn) {
			data.fOtherMusic = otherAudio.value;
			audioOther.volume = data.fOtherMusic;
		}
		else data.fOtherMusic = 0;

		PlayerPrefs.SetFloat("fBasicMusic", data.fBasicMusic);
		PlayerPrefs.SetFloat("fOtherMusic", data.fOtherMusic);

		PlayerPrefs.Save();

	}

	public void SettingGame() {
		basicPanel.SetActive(false);
		settingsPanel.SetActive(true);

		if ( data.fBasicMusic == 0) {
			basicAudioToggle.GetComponent<Toggle>().isOn = false;
			basicAudio.value = 0;
		} else basicAudio.value = data.fBasicMusic;

		if ( data.fOtherMusic == 0) {
			otherAudioToggle.GetComponent<Toggle>().isOn = false;
			otherAudio.value = 0;
		} else otherAudio.value = data.fOtherMusic;
	}

	public void Back() {
		basicPanel.SetActive(true);
		settingsPanel.SetActive(false);

		AudioVolume();
	}

	public void ExitGame() {
		Application.Quit();
	}

	public void AudioOtherPlay(){
		if (otherAudioToggle.GetComponent<Toggle>().isOn) audioOther.Stop();
		if (otherAudioToggle.GetComponent<Toggle>().isOn) audioOther.Play();
	}
}
