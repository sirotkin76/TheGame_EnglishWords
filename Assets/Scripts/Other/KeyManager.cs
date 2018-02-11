using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyManager : MonoBehaviour {

	public PlayerData data;

	public GameObject basicPanel;
	public GameObject GameOver;
	public GameObject PausePanel;

	bool activePanel;


	// Update is called once per frame
	void FixedUpdate () {

		if (Input.GetKeyDown(KeyCode.Escape) && !PausePanel.active) {

			if (basicPanel.active) activePanel = true;
			else activePanel = false;

			basicPanel.SetActive(false);
			GameOver.SetActive(false);
			PausePanel.SetActive(true);

		} else if (Input.GetKeyDown(KeyCode.Escape) && PausePanel.active) {
			ContinueGame();
		}
	}

	public void ContinueGame() {
		if (activePanel) basicPanel.SetActive(true);
		else GameOver.SetActive(true);

		PausePanel.SetActive(false);
	}

	public void ExitGame() {
		SaveGame();

		Application.Quit();
	}

	public void SaveGame() {
				
		PlayerPrefs.SetInt("Score", data.Score);
		PlayerPrefs.SetInt("Trying", data.Trying);
		PlayerPrefs.SetInt("QuessedWord", data.QuessedWord);
		PlayerPrefs.SetInt("DefaultTry", data.DefaultTry);
		PlayerPrefs.SetInt("DefaultScoreOneLetter", data.DefaultScoreOneLetter);
		PlayerPrefs.SetInt("MaxLengthWord", data.MaxLengthWord);
		PlayerPrefs.SetInt("MinLengthWord", data.MinLengthWord);

		if (data.OftenRepeatedWords) PlayerPrefs.SetInt("OftenRepeatedWords", 1);
		else PlayerPrefs.SetInt("OftenRepeatedWords", 0);

		PlayerPrefs.SetInt("iStart", data.iStart);
		PlayerPrefs.SetInt("iFinish", data.iFinish);

		PlayerPrefs.Save();

	}
}
