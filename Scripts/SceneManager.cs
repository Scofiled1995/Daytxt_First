using UnityEngine;
using System.Collections;

public class SceneManager : SingleTon<SceneManager> {

	public void Jump2NextSceneAsync(string sceneName)
	{
		Application.LoadLevelAsync (sceneName);
	}
	
}
