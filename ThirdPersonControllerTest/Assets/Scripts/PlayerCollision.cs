using UnityEngine;
using System.Collections;

public class PlayerCollision : MonoBehaviour {

	GameObject HUDCanvas;
	Animator anim;
	GameObject cop;
	AIPatrolMovement copPatrol;
	bool copInRange;
	GameObject[] cops;

	void Start () {
		HUDCanvas = GameObject.FindGameObjectWithTag ("HUDCanvas");
		anim = HUDCanvas.GetComponent<Animator> ();
		cops = GameObject.FindGameObjectsWithTag ("Cop");
	}


	void Update () {
		if (copInRange) {
			anim.SetTrigger ("EnemyCollision");
			if (Input.GetKey(KeyCode.L)) {
				anim.SetTrigger("BackToGame");
			}
		}
	}

	void OnCollisionEnter (Collision col) {
		GameObject copHit = col;
		int pos = cops.IndexOf(cops, copHit);
		if (pos > -1) {
			copInRange = true;
		}
	}

}
