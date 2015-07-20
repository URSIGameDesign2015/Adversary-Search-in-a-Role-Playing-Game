using UnityEngine;
using System.Collections;

public class PosterRendering : MonoBehaviour {

	public float timeBetweenBullets = 0f;
	public float range = 10f;
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
					Instantiate (poster, shootHit.point, Quaternion.identity);
					Debug.Log ("instantiate");
				}
			}
		}
	}
}
	
	
//	void Shoot ()
//	{
//		shootRay = Camera.main.ScreenPointToRay (Input.mousePosition);
//		if (Physics.Raycast (shootRay, out shootHit, range, shootableMask)) {
//			if (shootHit.collider.tag == "canTag") {
//				Instantiate (poster, shootHit.point, Quaternion.identity);
//				Debug.Log ("instantiate");
//			}
//		}
//	}
	