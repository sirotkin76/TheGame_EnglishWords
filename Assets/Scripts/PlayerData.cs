using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerData : ScriptableObject {

	[HideInInspector]
	public int Score;
	[HideInInspector]
	public int Trying;
	[HideInInspector]
	public int QuessedWord;

	public int DefaultTry;
	public int DefaultScoreOneLetter;

	public int MaxLengthWord = 10;
	public int MinLengthWord = 4;

	public bool OftenRepeatedWords;

	[HideInInspector]
	public int iStart;
	[HideInInspector]
	public int iFinish;

}
