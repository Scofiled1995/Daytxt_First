using UnityEngine;
using System.Collections;

public class SoundsManager : MonoBehaviour {
	private static SoundsManager _instance;
	private static AudioSource asource;

	public void PlayBackgroundMusic(string clipName,bool loop = false)
	{
		Global_Game.backgroundMusic = clipName;
		asource.clip = Resources.Load(Global_Game.backgroundMusic) as AudioClip;
		asource.loop = loop;
		asource.Play(); 
	}
	public void PlayEffectSounds(string clipName)
	{
		GameObject obj = new GameObject ();
		obj.name = "Effect Sounds";
		AudioSource sound = obj.AddComponent<AudioSource>();
		Global_Game.effectMusic = clipName;
		sound.playOnAwake = false;
		sound.clip = Resources.Load (Global_Game.effectMusic) as AudioClip;
		sound.Play ();
		Destroy (obj,1);
	}

	public static SoundsManager GetInstance()
	{
		if (!_instance) {
			GameObject obj = new GameObject();
			obj.name = typeof(SoundsManager).ToString();
			asource = obj.AddComponent<AudioSource>();
			asource.clip = Resources.Load(Global_Game.backgroundMusic) as AudioClip;
			asource.playOnAwake = false;
			_instance = obj.AddComponent<SoundsManager>();
			DontDestroyOnLoad(obj);
		}
		return _instance;
	}




}
