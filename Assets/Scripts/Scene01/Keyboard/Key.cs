using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class Key : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerClickHandler {

	public Color activeColor;
	Color color;

	Image img;

	private GameObject scriptNewWord;

	// Use this for initialization
	void Start () {
		img = GetComponent<Image>();
		color = img.color;
		scriptNewWord = GameObject.FindGameObjectWithTag("NewWord");
	}
	
	public void OnPointerEnter (PointerEventData eventData) {
		img.color = activeColor;
	}
	
	public void OnPointerExit (PointerEventData eventData) {
		img.color = color;
	}

	void OnDisbale() {
		img.color = color;
	}

	public void OnPointerClick(PointerEventData eventData) {
		char el = GetComponent<KeyValue>().keyVlaue;
		img.color = color;
		gameObject.SetActive(false);
		scriptNewWord.GetComponent<NewWord>().CompareLatter(el);
	}
}
