using UnityEngine;
using System.Collections;

[RequireComponent(typeof(BoxCollider))]
public class GemsColliderDetector : MonoBehaviour {
	private ScoreManger sMer;
	// Use this for initialization
	void Start () {
		sMer = GameObject.Find("UI Root/Target Score").GetComponent<ScoreManger>();
		transform.GetComponent<Collider> ().isTrigger = true;
	}

	void OnTriggerEnter(Collider other)
	{
		if (other.name.Equals ("AngryBall")) {
			sMer.AddScore();
			if(this.gameObject.tag.Equals("xingxing"))
				sMer.AddStar();
			Destroy(this.gameObject);
		}
	}
}
