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


	void Update ()
	{	
		timer += Time.deltaTime;

		if (Input.GetButton ("Fire1") && timer > timeBetweenBullets && Time.timeScale != 0) {
			shootRay = Camera.main.ScreenPointToRay (Input.mousePosition);
			RaycastHit shootHit;
			if (Physics.Raycast (shootRay, out shootHit, range, shootableMask)) {
				Debug.Log("something happened");
				if (shootHit.collider.tag == "canTag") {
					Vector3 helperPoint = shootHit.point;
					helperPoint.y += 1;
					Vector3 side1 = helperPoint - shootHit.point;
					Vector3 normal = Vector3.Cross(side1, transform.up).normalized;
					Vector3 normalAngles = normal * 90; 
					Quaternion rotation = Quaternion.Euler(normalAngles[2], normalAngles[0], normalAngles[1]);
					Instantiate (poster, shootHit.point, rotation);
					Debug.Log ("object spawned");
				}
			}
		}
	}
}
	