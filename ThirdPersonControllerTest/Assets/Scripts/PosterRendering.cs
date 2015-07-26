using UnityEngine;
using System.Collections;

public class PosterRendering : MonoBehaviour {

	public float timeBetweenBullets = 0f;
	public float range = 100f;
	public GameObject poster;

	float timer;
	Ray shootRay;
	int shootableMask;
	Transform playerTransform; 

	void Awake ()
	{
		shootableMask = LayerMask.GetMask ("Shootable");
		playerTransform = GetComponent<Transform> ();
	}


	void Update ()
	{	
		if (Input.GetButton ("Fire1")) {
			shootRay = Camera.main.ScreenPointToRay (Input.mousePosition);
			RaycastHit shootHit;
			if (Physics.Raycast (shootRay, out shootHit, range, shootableMask)) {
				if (shootHit.collider.tag == "canTag") {
					Quaternion rotation = Quaternion.FromToRotation(shootHit.point, playerTransform.position);
					Instantiate (poster, shootHit.point, rotation);
				}
			}
		}
	}
}
	