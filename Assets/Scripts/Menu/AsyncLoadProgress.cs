using UnityEngine;
using System.Collections;

public class AsyncLoadProgress : MonoBehaviour {

	private AsyncOperation async = null;
	private bool isLoading = false;
	public string levelName = "Scene01";

	public PlayerData data;

	private IEnumerator _Start() {
		async = Application.LoadLevelAsync(levelName);

		while( !async.isDone ) yield return null;
		
		isLoading = false;
		yield return async;
	}

	public void LoadLevel() {
		data.RestartGame = false;
		isLoading = true;
		StartCoroutine("_Start"); //код согласия
	}

	public void NewLoadGame() {
		data.RestartGame = true;
		isLoading = true;
		StartCoroutine("_Start"); //код согласия
	}

	// private void OnGUI() {
	// 	if ( !isLoading ) {
	// 		if ( GUI.Button( new Rect( ( Screen.width*0.5f ) - 200, Screen.height*0.6f, 400, 100 ), "Играть" ) ) {
			
	// 			isLoading = true;
	// 			StartCoroutine("_Start"); //код согласия
	// 		}
	// 	} 
	// 	else GUI.HorizontalScrollbar( new Rect( 25, 12, ( Screen.width - 50), 25 ), 0, async.progress*100, 0, 100 );
	// }

}
 