using UnityEngine;
using System.Collections;

public class GameResultOperator : MonoBehaviour {
	public GameObject newGameBtn;
	public GameObject backStartBtn;
	// Use this for initialization
	void Start () {
		UIEventListener.Get (newGameBtn).onClick = ClickCallBack;
		UIEventListener.Get (backStartBtn).onClick = ClickCallBack;
	}

	void ClickCallBack(GameObject btn)
	{
		switch (btn.name) {
		case "NewGame":
			Director.GetInstance().ResumeGame();
			Director.GetInstance().NewGame();
			break;
		case "BackStartGame":
			Global_Game.nextSceneName = "StartScene";
			Director.GetInstance().ResumeGame();
			Debug.Log("---------");
			SceneManager.GetInstance().Jump2NextSceneAsync(Global_Game.nextSceneName);
			break;
		default:
			break;
		}
	}
}
