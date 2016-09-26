using UnityEngine;
using System.Collections;

public class EnterGame : MonoBehaviour {

	void OnClick()
	{
		Global_Game.nextSceneName = "SelectGameScene";
		SceneManager.GetInstance ().Jump2NextSceneAsync (Global_Game.nextSceneName);

	}
}
