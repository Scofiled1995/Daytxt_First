using UnityEngine;
using System.Collections;

public class Director : SingleTon<Director> {

	public string fileName = "LevelConfig.xml";
	public string content;

	// Use this for initialization
	public void StartGame () {
		SoundsManager.GetInstance ().PlayBackgroundMusic ("Sounds/background",true);
		StartCoroutine (InitializeLevelsConfig());
		//在跳转到另一个场景的时候，Dirctor脚本所挂载的对象不会消除
		DontDestroyOnLoad (this.gameObject);
	

	}
	//初始化游戏
	public IEnumerator InitializeLevelsConfig()
	{

		//文件操作
		string srcPath = Application.streamingAssetsPath+ "/" + fileName;
		string derctPath = Application.persistentDataPath + "/" + fileName;
		Debug.Log (derctPath);
		if (!FileManager.GetInstance ().IsFileExists (derctPath)) {

			FileManager.GetInstance ().CopyFile (srcPath, derctPath);
		}
		yield return FileManager.GetInstance ().IsFileExists (derctPath);

		if (FileManager.GetInstance ().IsFileExists (derctPath)) {
			Global_Game.content ="Pass";
			FileManager.GetInstance ().ParseLevelsConfigXMLFile (derctPath);
		
		}

	}

	//游戏暂停
	public void PauseGame()
	{
		Time.timeScale = 0;
	}
	//游戏继续
	public void ResumeGame()
	{
		Time.timeScale = 1;
	}
	//游戏结束
	public void ExitGame()
	{
		Application.Quit ();
	}
	//重玩
	public void NewGame()
	{
		Application.LoadLevelAsync (Application.loadedLevel);

	}
	void OnGUI()
	{
		GUI.skin.label.fontSize =10;
		GUI.Label (new Rect(0,0,Screen.width,Screen.height),Global_Game.content);
	}

	
}
