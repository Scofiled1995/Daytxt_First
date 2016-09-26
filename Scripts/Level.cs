using UnityEngine;
using System.Collections;

[System.Serializable]

public class Level  {
	public int levelNumber;//关卡数
	public bool isLock;//是否上锁
	public int star;//星数
	public int times;//通关时间
	public int targetScore;

	public Level(int lv,bool il,int st,int tm,int trs = 3)
	{
		levelNumber = lv;
		isLock = il;
		star = st;
		times = tm;
		targetScore = trs;
	}
}
