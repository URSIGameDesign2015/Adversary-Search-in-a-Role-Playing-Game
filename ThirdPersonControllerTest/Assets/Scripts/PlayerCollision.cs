using UnityEngine;
using System.Collections;

public class PlayerCollision : MonoBehaviour {

	GameObject HUDCanvas;
	Animator anim;
	GameObject cop;
	AIPatrolMovement copPatrol;

	void Start () {
		HUDCanvas = GameObject.FindGameObjectWithTag ("HUDCanvas");
		anim = HUDCanvas.GetComponent<Animator> ();
	}


	void OnCollisionEnter (Collision col) {
		if (col.gameObject.tag == "Cop") {
			anim.SetTrigger ("EnemyCollision");
			if (Input.GetKey(KeyCode.L)) {
				anim.SetTrigger ("BackToGame");
			}
		}
	}

}
