using UnityEngine;
using UnityEditor;
 
public class PlayerDataAsset
{
	[MenuItem("Assets/Create/Player Data")]
	public static void CreateAsset ()
	{
		ScriptableObjectUtility.CreateAsset<PlayerData> ();
	}
}