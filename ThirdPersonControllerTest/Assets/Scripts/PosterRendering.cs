using UnityEngine;
using System.Collections;

public class PosterRendering : MonoBehaviour {

	public float timeBetweenBullets = 0f;
	public float range = 100f;
	public GameObject poster;

	float timer;
	Ray shootRay;
	int shootableMask;

	void Awake ()
	{
		shootableMask = LayerMask.GetMask ("Shootable");
	}


	void Update ()
	{	
		if (Input.GetButton ("Fire1")) {
			shootRay = Camera.main.ScreenPointToRay (Input.mousePosition);
			RaycastHit shootHit;
			if (Physics.Raycast (shootRay, out shootHit, range, shootableMask)) {
				if (shootHit.collider.tag == "canTag") {
					Vector3 relativePos = shootHit.transform.position - transform.position;
					Quaternion rotation = Quaternion.LookRotation(relativePos);
					Instantiate (poster, shootHit.point, rotation);
				}
			}
		}
	}
}
	