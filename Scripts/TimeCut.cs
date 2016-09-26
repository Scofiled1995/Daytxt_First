using UnityEngine;
using System.Collections;

public class TimeCut : MonoBehaviour {
	private GameObject angryBall;
	private AngryBallState angryBallState;
	public int currentLevel;//当前等级关卡
	private int totalTime;//总时间
	private float currentTime = 0f;
	public UIProgressBar progressBar;
	public bool timeRest = false;//倒计时控制

	// Use this for initialization
	void Start () {
		angryBall = GameObject.Find ("AngryBall");
		angryBallState = angryBall.GetComponent<AngryBallState> ();
		currentLevel = int.Parse(Application.loadedLevelName.Substring (5));
		totalTime = LevelConfig.GetInstance ().levelsConfig [currentLevel - 1].times;
		progressBar= transform.GetComponent<UIProgressBar>();


	}
	
	// Update is called once per frame
	void LateUpdate () {
		if (timeRest ||angryBallState.ballState!=AngryBallState.BallState.None)
			return;
		float progress = 1f/totalTime * Time.deltaTime;

		progressBar.value -= progress; 
		if (progressBar.value == 0f) {
			angryBallState.Change2FailureState();
		}
	}
}
