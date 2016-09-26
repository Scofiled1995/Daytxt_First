using UnityEngine;
using System.Collections;

public class CameraFollowBall : MonoBehaviour {
	public float zDistance = 15.0f;
	public float yHeight = 10f;

	public Transform target;
	public float damping = 2f;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void LateUpdate () {

		Vector3 newPosition = target.position + new Vector3 (0,yHeight,-zDistance);
		transform.position = Vector3.Lerp (transform.position,newPosition,Time.deltaTime*damping);
	}
}
