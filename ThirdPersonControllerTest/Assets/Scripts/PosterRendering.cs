using UnityEngine;
using System.Collections;

public class PosterRendering : MonoBehaviour {

	public float timeBetweenBullets = 0.15f;
	public float range = 100f;
	public Object poster;

	float timer;
	Ray shootRay;
	RaycastHit shootHit;
	int shootableMask;

	void Awake ()
	{
		shootableMask = LayerMask.GetMask ("Shootable");
	}


	void Update ()
	{	
		if(Input.GetButton ("Fire1")) {
			Shoot ();
		}

	}
	
	
	void Shoot ()
	{
		shootRay = Camera.main.ScreenPointToRay (Input.mousePosition);
		if (Physics.Raycast (shootRay, out shootHit, range, shootableMask)) {
			if (shootHit.collider.tag == "canTag") {
				Instantiate (poster, shootHit.point, Quaternion.identity);
			}
		}
	}

}