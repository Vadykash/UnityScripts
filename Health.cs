using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(CharacterController))]
public class Health : MonoBehaviour {

	public  float minimum_height_ = 2.0f;
	public  float height_damage_multiplier_ = 1.0f;
	public  float height_check_distance_ = 200;
	private CharacterController character_controller_;

	private bool  is_in_air_ = false;
	private float height_ = 0;

	// Use this for initialization
	void Start () {
		character_controller_ = GetComponent<CharacterController>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void takeDamage(float damage) {
		Debug.Log ("Damage: " + damage.ToString());
	}

	void FixedUpdate () {
		bool is_grounded = character_controller_.isGrounded;

		if (!is_in_air_) {
			if (!is_grounded) {
				float height = CalcHeight ();

				if (height > minimum_height_) {
					Debug.Log ("is_grounded: " + is_grounded.ToString() + ", height: " + height.ToString());	
					height_ = height;
					is_in_air_ = true;
				}
			}
		} else {
			if (is_grounded) {
				is_in_air_ = false;
				float damage = height_ * height_damage_multiplier_;
				takeDamage (damage);
			}
		}
	}

	float CalcHeight() {
		//Vector3 origin = character_controller_.center;
		Vector3 origin = transform.position;
		Vector3 direction = new Vector3 (0, -1, 0);

		float result = 0;
		RaycastHit hit;
		if (Physics.Raycast (origin, direction, out hit, height_check_distance_)) {
			result = hit.distance;
		}

		return result;
	}		

}
