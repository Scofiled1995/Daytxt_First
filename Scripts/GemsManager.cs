using UnityEngine;
using System.Collections;
using System.Collections.Generic;
public class GemsManager : MonoBehaviour {
	public List<GameObject> gems = new List<GameObject>();
	// Use this for initialization
	void Start () {
		foreach (Transform tr in transform) {
			gems.Add(tr.gameObject);
			tr.gameObject.AddComponent<GemsColliderDetector>();
	}

	}

	// Update is called once per frame
	void Update () {
		
	}
}
