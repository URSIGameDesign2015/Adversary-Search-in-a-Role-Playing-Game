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

	void OnCollisionEnter (Collision col) {
		GameObject colHit = col.gameObject;
		for (int i= 0; i < cops.Length; i++) {
			if (cops [i] == colHit) {
				copInRange = true;
			}
		}
	}

	void Update () {
		if (copInRange) {
			anim.SetTrigger ("EnemyCollision");
			if (Input.GetKey(KeyCode.L)) {
				anim.SetTrigger("BackToGame");
			}
		}
	}

}
