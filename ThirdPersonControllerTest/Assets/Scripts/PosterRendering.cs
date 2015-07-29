using UnityEngine;
using System.Collections;

public class PosterRendering : MonoBehaviour {

	public float timeBetweenBullets = 1.0f;
	public float range = 100.0f;
	public GameObject poster;

	float timer;
	Ray shootRay;
	int shootableMask;
//	Transform playerTransform; 

	void Awake ()
	{
		shootableMask = LayerMask.GetMask ("Shootable");
//		playerTransform = GetComponent<Transform> ();
	}


	void FixedUpdate ()
	{	
		timer += Time.deltaTime;

		if (Input.GetButton ("Fire1") && timer > timeBetweenBullets) {
			shootRay = Camera.main.ScreenPointToRay (Input.mousePosition);
			RaycastHit shootHit;
			if (Physics.Raycast (shootRay, out shootHit, range, shootableMask)) {
				if (shootHit.collider.tag == "canTag") {
					Vector3 helperPointOne = shootHit.point;
					helperPointOne.y -= 1;
					Vector3 side1 = helperPointOne - shootHit.point;
					Vector3 helperPointTwo = helperPointOne;
					helperPointTwo.x += 1;
					Vector3 side2 = helperPointTwo - shootHit.point;
					Vector3 normal = Vector3.Cross(side1, side2).normalized;
					Quaternion rotation = Quaternion.FromToRotation(normal, transform.up);
					Instantiate (poster, shootHit.point, rotation);
					timer = 0;
				}
			}
		}
	}
}
	