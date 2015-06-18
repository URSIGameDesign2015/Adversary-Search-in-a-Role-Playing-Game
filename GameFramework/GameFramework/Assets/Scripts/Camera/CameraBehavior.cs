using UnityEngine;
using System.Collections;

public class CameraBehavior : MonoBehaviour {

	public Transform target;
	public float smoothing = 5f;
	float camRayLength = 100f;
	int floorMask;
	
	Vector3 offset;

//	void Awake() {
//		floorMask = LayerMask.GetMask ("Floor");
//	}

	void Start(){
		offset = transform.position - target.position;
	}
	
	void FixedUpdate(){
		Vector3 targetCamPos = target.position + offset;
		transform.position = Vector3.Lerp (transform.position, targetCamPos,
		                                   smoothing * Time.deltaTime);
		//Turning ();
	}

//	void Turning () {
//		Ray camRay = Camera.main.ScreenPointToRay (Input.mousePosition);
//		RaycastHit floorHit;
//		if (Physics.Raycast (camRay, out floorHit, camRayLength, floorMask)) {
//			Vector3 playerToMouse = floorHit.point - transform.position;
//			playerToMouse.y = 0f;
//			
//			Quaternion newRotation = Quaternion.LookRotation (playerToMouse);
//			transform.MoveRotation (newRotation);
//		}
	//}

}
