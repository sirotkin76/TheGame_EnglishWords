using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Keyboard : MonoBehaviour {

	[HideInInspector]
	public GameObject prefabKey; // Лист клавиш

	void Start () {
		for (char c = 'A'; c <= 'Z'; c++) {
			GameObject a = (GameObject)Instantiate(prefabKey);
			a.GetComponent<KeyValue>().keyVlaue = c;
			a.gameObject.GetComponentInChildren<Text>().text = char.ToString(c);
     		a.transform.SetParent(transform, false);
		}
	}
	
	public void UpdateKeyButton() {
		for (int i=0; i < transform.childCount; i++) transform.GetChild(i).gameObject.SetActive(true);
	}

}
