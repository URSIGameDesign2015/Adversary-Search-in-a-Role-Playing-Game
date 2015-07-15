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
	float effectsDisplayTime = 0.2f;

	void Awake ()
	{
		shootableMask = LayerMask.GetMask ("Shootable");
		aimLine = GetComponent <LineRenderer> ();
	}
	
	
	void Update ()
	{
		timer += Time.deltaTime;
		
		if(Input.GetButton ("Fire1") && timer >= timeBetweenBullets && Time.timeScale != 0)
		{
			Shoot ();
		}

	}
	
	
	void Shoot ()
	{
		timer = 0f;
		
		if (Physics.Raycast (new Vector3 (Input.mousePosition.x, Input.mousePosition.y, 0), out shootHit, range, shootableMask)) {
			if (shootHit.collider.tag == "canTag") {
				Instantiate (poster, shootHit.point, Quaternion.identity);
			}
		} else {
			return;
		}
	}
}