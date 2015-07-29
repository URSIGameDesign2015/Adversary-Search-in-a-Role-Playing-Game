using UnityEngine;
using System.Collections;

public class PosterChoice : MonoBehaviour {

	Animator anim;

	void Awake () {
		anim = GetComponent<Animator> ();
	}

	void Update () {
		if (Input.GetKey (KeyCode.A)){
			anim.SetTrigger("PosterChoice");
		}

	}

}
