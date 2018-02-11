using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SettingsGame : MonoBehaviour {

	public PlayerData data;  // Данные пользователя

	public Text textScore; // Текст для очков
	public Text textTry;
	public Text textQuessed;

	public GameObject keyboard;
	public GameObject newWord;

	void Start () {
		UpdateText();
	}

	public void SetScore(int count) {
		data.Score += count;
		textScore.text = data.Score.ToString() ;
	}

	public void DeductTry() {
		data.Trying--;
		textTry.text  = data.Trying.ToString();

		if (data.Trying <= 0) GameOver();
	}

	void GameOver() {
		transform.GetChild(0).transform.gameObject.SetActive(false);
		transform.GetChild(1).transform.gameObject.SetActive(true);
	}

	public void ResetNewGame() {

		transform.GetChild(0).transform.gameObject.SetActive(true);
		transform.GetChild(1).transform.gameObject.SetActive(false);
		transform.GetChild(2).transform.gameObject.SetActive(false);

		data.Trying = data.DefaultTry;
		data.iFinish = 0;
		data.iStart = 0;
		data.QuessedWord = 0;
		data.Score = 0;

		UpdateText();

		for (int i = 0; i < keyboard.transform.childCount; i++) keyboard.transform.GetChild(i).gameObject.SetActive(true);
		
		newWord.GetComponent<NewWord>().SetNewWord();
	}

	public void UpdateText() {
		textScore.text = data.Score.ToString();
		textTry.text = data.Trying.ToString();
		textQuessed.text = data.QuessedWord.ToString();
	}
}
