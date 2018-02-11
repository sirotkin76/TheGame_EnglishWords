using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NewWord : MonoBehaviour {

	public PlayerData data;

	public string[] word;

	public GameObject prefabLetter;
	public GameObject canvasFunc;
	public GameObject keyboard;

	public Text textGuessedTheWords;
	public Text textTrying;
	public Text textScore;

	public List<string> list;

	public KeyManager keyManag;

	bool timerRing;
	float timer = 0;
	int countWord;
	string w;

	public void SetNewWord() {
		 // Слов больше нет
		if (list.Count - (data.iFinish + data.iStart) == 0) {
			data.iFinish = 0;
			data.iStart = 0;
			SetNewWord();
			return;
		};

		// Проверяем условия отбора слова
		if (data.OftenRepeatedWords) w = list[data.iStart]; // часто повторяемые слова ищем слова с конца
		else w = list[list.Count - data.iFinish]; // ищем слова с начала так как список уже отсортирован
		
		for (int i = 0; i < transform.childCount; i++) Destroy(transform.GetChild(i).gameObject);

		for (int i = 0; i < w.Length; i++) {
			GameObject a = (GameObject)Instantiate(prefabLetter);
			a.GetComponent<LatterValue>().latterValue =  w[i];
			a.gameObject.GetComponentInChildren<Text>().text = char.ToString(w[i]);
			a.gameObject.GetComponentInChildren<Text>().enabled = false;
			a.transform.SetParent(transform, false);
		}
		
		textGuessedTheWords.text = data.QuessedWord.ToString();

		countWord = w.Length;

		keyManag.SaveGame();
	}

	public void CompareLatter(char c) {
		bool res = false;

		for (int i = 0; i < transform.childCount; i++) {
			char letter = transform.GetChild(i).GetComponent<LatterValue>().latterValue;

			if ( c.ToString().ToUpper() == letter.ToString().ToUpper()) {
				// Открываем букву
				transform.GetChild(i).gameObject.transform.GetChild(0).GetComponent<Text>().enabled = true;

				// Прибавляем очков
				data.Score += data.DefaultScoreOneLetter;
				textScore.text = data.Score.ToString();

				res = true;
				countWord --;
			}
		}

		// Если слово отгадано то обновляем слово
		if (countWord <= 0) {
			data.QuessedWord ++;
			keyboard.GetComponent<Keyboard>().UpdateKeyButton();
			data.Trying += data.DefaultTry;
			textTrying.text = data.Trying.ToString();

			timerRing = true;
			// Проверяем условия отбора слова
			if (data.OftenRepeatedWords) data.iStart++; // часто повторяемые слова ищем слова с конца
			else data.iFinish++; // ищем слова с начала так как список уже отсортирован
		}

		if (!res) canvasFunc.gameObject.GetComponent<SettingsGame>().DeductTry(); // Вычитаем попытки
	
	}

	void FixedUpdate() {
		if (timerRing) {
			if (timer >= 1.5f) {
				timerRing = false;
				timer = 0;
				SetNewWord();
			}
			else timer += Time.deltaTime;
			

		}
	}

}
