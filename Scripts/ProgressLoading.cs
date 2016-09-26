using UnityEngine;
using System.Collections;

public class ProgressLoading : MonoBehaviour {
	public float progressTime = 5f;
	private UIProgressBar progressBar;
	private bool isJumpState = false;
	// Use this for initialization
	void Start () {
		progressBar = GetComponent<UIProgressBar>();
		progressBar.value = 0;
	
	}
	
	// Update is called once per frame
	void Update () {
		//假加载
		float speed = 1 / progressTime;
		float progress = speed * Time.deltaTime;
		progressBar.value += progress;

		if(progressBar.value == 1f && !isJumpState){
			isJumpState = true;
			Global_Game.nextSceneName = "StartScene";
			Director.GetInstance ().StartGame ();
			SceneManager.GetInstance().Jump2NextSceneAsync(Global_Game.nextSceneName);
		}
	}
}
