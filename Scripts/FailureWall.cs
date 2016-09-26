using UnityEngine;
using System.Collections;

public class FailureWall : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter(Collider other)
	{
		Debug.Log (other.name);
		if (other.name.Equals ("AngryBall")) {
			//变成失败状态
			other.gameObject.GetComponent<AngryBallState>().Change2FailureState();
		}
	}
}
