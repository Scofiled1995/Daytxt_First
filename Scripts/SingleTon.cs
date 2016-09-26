using UnityEngine;
using System.Collections;
using System;

public class SingleTon<T> : MonoBehaviour where T:MonoBehaviour {

	private static T _instance;
	/// <summary>
	/// Gets the instance.
	/// </summary>
	/// <returns>The instance.</returns>
	public static T GetInstance()
	{
		if (!_instance) {
			GameObject obj = new GameObject();
			obj.name = typeof(T).ToString();
			_instance = obj.AddComponent<T>();
			DontDestroyOnLoad(obj);
		}
		return _instance;
	}

}
