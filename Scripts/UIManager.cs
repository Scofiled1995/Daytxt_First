using UnityEngine;
using System.Collections;

public class UIManager : MonoBehaviour {
	public GameObject gameResultOperatorMianBan;
	public UISprite gameResultIcon; 
//	public GameObject gameContr;
	[System.Serializable]public enum GameResultOperatorMianBanType{
		None = -1,
		FailureMianBan= 0,
		WinMianBan
	}

	// Use this for initialization
	void Start () {
		transform.Translate (1,1,1,Space.Self);
		ActiveGameResultMianBan (false, GameResultOperatorMianBanType.None);
		transform.Find("Pause").gameObject.AddComponent<LevelController> ();
	}

	public void ActiveGameResultMianBan(bool active,GameResultOperatorMianBanType results)
	{
		gameResultOperatorMianBan.SetActive(active);
		if (!active)
			return;

		//游戏失败
		if(results == GameResultOperatorMianBanType.FailureMianBan)
			gameResultIcon.spriteName = "ZhanDouShiBai";
		//游戏通关
		else if(results == GameResultOperatorMianBanType.WinMianBan)
			gameResultIcon.spriteName = "ZhanDouShengLi";

	}


}
