using UnityEngine;
using System.Collections;

public class LevelController : MonoBehaviour {
	bool isPause=false;
	
	void OnClick()
	{
		isPause = !isPause;
		if (isPause)
			Director.GetInstance ().PauseGame ();
		else
			Director.GetInstance ().ResumeGame ();
	}
}
