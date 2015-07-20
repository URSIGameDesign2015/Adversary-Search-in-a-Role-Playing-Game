using UnityEngine;
using System.Collections;

public class PosterChoice : MonoBehaviour {

	Animator anim;
	double posterIndicator;

	void Awake () {
		anim = GetComponent<Animator> ();
	}

	void Update () {
		posterIndicator = Input.GetKey ();
		if (posterIndicator == "1") {
			return;
		}

	}

}
