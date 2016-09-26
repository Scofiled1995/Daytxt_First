using UnityEngine;
using System.Collections;
using System.Collections.Generic;
public class LevelConfig : SingleTon<LevelConfig> {
	public List<Level> levelsConfig = new List<Level>();
	public Transform levelsContainer;
	// Use this for initialization
	/*
	public List<Level> GetLevelsConfig () {
		if(levelsConfig.Count==0){
			//可以解析XML获取
			levelsConfig.Add(new Level(1,false,2));
			levelsConfig.Add(new Level(2,false,1));
			levelsConfig.Add(new Level(3,false,1));
			levelsConfig.Add(new Level(4,false,1));
			levelsConfig.Add(new Level(5,false,1));
			levelsConfig.Add(new Level(6,false,3));
			levelsConfig.Add(new Level(7,false,3));
			levelsConfig.Add(new Level(8,false,2));
			levelsConfig.Add(new Level(9,true,0));
			levelsConfig.Add(new Level(10,true,0));
			levelsConfig.Add(new Level(11,true,0));
		};
		return levelsConfig;
	}
*/
	public void ConfigLevelTag()
	{
		Debug.Log (levelsConfig.Count);
		levelsContainer = GameObject.Find("Levels Container").transform;
		if (!levelsContainer)
			return;

		int i = 0;
		foreach (Transform child in levelsContainer) {
			//修改Level的标签
			child.tag = levelsConfig[i].isLock ? "lock":"unLock";
			UISprite sp = child.GetComponent<UISprite>();
			UIButton bt = child.GetComponent<UIButton>();

			sp.spriteName = levelsConfig[i].isLock ? Global_Game.lockTextureName : Global_Game.unLockTextureName;
			bt.normalSprite = sp.spriteName;

			child.FindChild("Stars").gameObject.SetActive(!levelsConfig[i].isLock);

			for (int j = 0;j < levelsConfig[i].star;j++)
			{
				UISprite d_sp = child.FindChild("Stars").FindChild("Star"+(j+1).ToString()).GetComponent<UISprite>();
				d_sp.spriteName = Global_Game.star_unLock;
			}
			i++;
		}
	}
}
