using UnityEngine;
using System.Collections;

public class ZhuanTiRotate : MonoBehaviour {
	public float rotateSpeed = 20f;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		float rot = rotateSpeed * Time.deltaTime;
		transform.Rotate (Vector3.up,rot,Space.World);
	}
}
