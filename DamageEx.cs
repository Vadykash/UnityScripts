using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageEx : MonoBehaviour {

	public  float damage_ = 5.0f;
	private Health health_;


	// Use this for initialization
	void Start () {
		
	}

	void OnTriggerEnter(Collider other) {
		Debug.Log ("Trigger enter");
		GameObject go = other.gameObject;
		Debug.Log (go);
		/*
		// All sense here
		if (this.GetComponent<PhotonViev> ().isMine) {
			if (go.CompareTag ("Player")) {
				Debug.Log ("Player");
				health_ = go.GetComponent<Health> ();
			}
		}
		*/
	}


	void OnTriggerExit(Collider other) {
		GameObject go = other.gameObject;
		if (go.CompareTag ("Player")) {
			health_ = null;
		}
	}

	void OnTriggerStay(Collider other) {
	}

	// Update is called once per frame
	void FixedUpdate () {
		if (health_) {
			health_.takeDamage(Time.deltaTime * damage_);
		}

	}
}
