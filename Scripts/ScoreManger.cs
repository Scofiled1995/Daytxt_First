using UnityEngine;
using System.Collections;

public class ScoreManger : MonoBehaviour {
	public UILabel scoreLabel;
	private int score = 0;
	private int star = 0;
	public int currentLevel;//当前等级关卡
	public int targetScore;//总的目标分数

	private GameObject angryBall;
	private AngryBallState angryBallState;
	void Start()
	{
		currentLevel = int.Parse(Application.loadedLevelName.Substring (5));
		targetScore = LevelConfig.GetInstance ().levelsConfig [currentLevel - 1].targetScore;
		scoreLabel.text = score + "/" + targetScore;

		angryBall = GameObject.Find ("AngryBall");
		angryBallState = angryBall.GetComponent<AngryBallState> ();
	}
	public void AddScore()
	{
		score += 1;
		scoreLabel.text = score + "/" + targetScore;
		if (score == targetScore) {
			FileManager.GetInstance().SaveCurrentLevel(Application.loadedLevelName,star);
			angryBallState.Change2WinState();
		}

	}
	public void AddStar()
	{
		star += 1;
	}
}
