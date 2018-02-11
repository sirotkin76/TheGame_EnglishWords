using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class loadTxt : MonoBehaviour {

	public PlayerData data;

	public string txtFile = "alice30"; // имя документа с английским текстом
	public Dictionary<string, int> dicString = new Dictionary<string, int> {};
	public GameObject newWorld; // Куда будем передавать словарь со словами
	public GameObject resetGame;

	private AudioSource basicAudio;

	string str, str1;

	void Start () {
		TextAsset txtAssets = (TextAsset)Resources.Load(txtFile);
		str = txtAssets.ToString();

		basicAudio = GetComponent<AudioSource>();

		for (int i = 0; i < str.Length; i++) {
			if (Char.IsLetter(str[i])) str1 = str1+str[i];
			else {
				if (str1 != null && str1.Length >= data.MinLengthWord && str1.Length <= data.MaxLengthWord) {
					if (dicString.ContainsKey(str1.ToString().ToUpper())) dicString[str1.ToString().ToUpper()]++;
					else dicString.Add(str1.ToString().ToUpper(), 1);
				}

				str1 = "";
			}
		}

		LoadGame();

		if (data.fBasicMusic == 0) basicAudio.Stop();
		else {
			basicAudio.volume = data.fBasicMusic;
			basicAudio.Play();
		}

		dicString = dicString.OrderBy(pair => pair.Value).ToDictionary(pair => pair.Key, pair => pair.Value);
		newWorld.GetComponent<NewWord>().list = dicString.Keys.ToList();
		

		if (!data.RestartGame) newWorld.GetComponent<NewWord>().SetNewWord();
		else resetGame.GetComponent<SettingsGame>().ResetNewGame();

		data.RestartGame = false;
	}

	void LoadGame() {
		# region PlayerPrefs
		data.Score = PlayerPrefs.GetInt("Score");
		data.Trying = PlayerPrefs.GetInt("Trying");
		data.QuessedWord = PlayerPrefs.GetInt("QuessedWord");
		data.DefaultTry = PlayerPrefs.GetInt("DefaultTry");
		data.DefaultScoreOneLetter = PlayerPrefs.GetInt("DefaultScoreOneLetter");
		data.MaxLengthWord = PlayerPrefs.GetInt("MaxLengthWord");
		data.MinLengthWord = PlayerPrefs.GetInt("MinLengthWord");

		if (PlayerPrefs.GetInt("OftenRepeatedWords") == 1) data.OftenRepeatedWords = true;
		else data.OftenRepeatedWords = false;

		data.iStart = PlayerPrefs.GetInt("iStart");
		data.iFinish = PlayerPrefs.GetInt("iFinish");

		data.fBasicMusic = PlayerPrefs.GetFloat("fBasicMusic");
		data.fOtherMusic = PlayerPrefs.GetFloat("fOtherMusic");

		#endregion
	}
}
