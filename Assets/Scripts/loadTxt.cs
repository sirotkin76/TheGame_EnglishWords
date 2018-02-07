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

	string str, str1;

	void Start () {
		TextAsset txtAssets = (TextAsset)Resources.Load(txtFile);
		str = txtAssets.ToString();

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

		dicString = dicString.OrderBy(pair => pair.Value).ToDictionary(pair => pair.Key, pair => pair.Value);
		newWorld.GetComponent<NewWord>().list = dicString.Keys.ToList();
		newWorld.GetComponent<NewWord>().SetNewWord();
	}
}
