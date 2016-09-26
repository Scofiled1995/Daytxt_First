using UnityEngine;
using System.Collections;

public class AngryBallState:MonoBehaviour {

	private GameObject root_ui;
	[System.Serializable]public enum BallState{
		None = 0,
		Win,
		Failure
	}
	public BallState ballState = BallState.None;
	
	public bool isShowFailure = false;
	public bool isShowWin = false;
	void Start()
	{
		ResetBallState ();
		root_ui = GameObject.Find ("UI Root");
	}
	public void Change2WinState()
	{
		//成功
		if (isShowWin)
			return;
		Debug.Log ("BallWinCall");
		isShowWin = true;
		ballState = BallState.Win;
		root_ui.GetComponent<UIManager> ().ActiveGameResultMianBan (isShowWin,UIManager.GameResultOperatorMianBanType.WinMianBan);
		Director.GetInstance ().PauseGame ();
	
	}

	public void Change2FailureState()
	{
		//失败
		if (isShowFailure)
			return;
		Debug.Log ("BallFailureCall");
		isShowFailure = true;
		ballState = BallState.Failure;
		root_ui.GetComponent<UIManager> ().ActiveGameResultMianBan (isShowFailure,UIManager.GameResultOperatorMianBanType.FailureMianBan);
		Director.GetInstance ().PauseGame ();
	}

	void FixedUpdate()
	{
		switch (ballState) {
		case BallState.None:
			break;
		case BallState.Win:
			Change2WinState();
			break;
		case BallState.Failure:
			Change2FailureState();
			break;
		default:
			break;
		}
	}

	public void ResetBallState()
	{
		ballState = BallState.None;
	}

}
