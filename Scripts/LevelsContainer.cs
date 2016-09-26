using UnityEngine;
using System.Collections;

public class LevelsContainer : MonoBehaviour {
	public GameObject tip;
	private bool isShowTip = false;

	// Use this for initialization
	void Start () {
		tip.SetActive(false);
		//配置关卡的tag标签
		LevelConfig.GetInstance ().ConfigLevelTag ();

		AddButtonEventDelegate ();
	}

	void AddButtonEventDelegate()
	{
		foreach (Transform child in this.transform) {
//2  绑定按钮监听事件
			UIEventListener.Get(child.gameObject).onClick = ButtonCallBack;

		}

	}
	void ButtonCallBack(GameObject obj)
	{
		if(isShowTip)return;
		if (obj.tag.Equals ("unLock")) {
			Global_Game.nextSceneName = obj.name;
			SceneManager.GetInstance().Jump2NextSceneAsync(Global_Game.nextSceneName);
		} else {
			tip.SetActive(true);
			isShowTip = true;
			Invoke("HideTip",1);
		}
	}

	void HideTip()
	{
		tip.SetActive(false);
		isShowTip = false;
	}
}
