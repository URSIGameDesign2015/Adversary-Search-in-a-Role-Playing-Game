using UnityEngine;
using System.Collections;

public class CopMovement : MonoBehaviour {

	// TO DO:
	// - Raycasting so we can see the player
	// - How do we go back to patrol area? -- go back to building GameObject?
 	// - How do we go back to patrolling? 
	//       -- have a bool that says if we are patrolling or not
	//       -- Initially & OnTriggerEnter --> we are patrolling 


	public float xMovement;
	public float zMovement;
	public int speed;
	public ArrayList checkpoints; 
	//public GameObject building;

	// what the enemy is moving toward
	Transform player;
	//PlayerHealth playerHealth;
	//EnemyHealth enemyHealth;
	NavMeshAgent nav;
	Vector3 movement;
	Rigidbody enemyRigidBody;
	//int currentStepCounter;

	void Awake ()
	{
		// where the player is
		player = GameObject.FindGameObjectWithTag ("Player").transform; 
		enemyRigidBody = GetComponent<Rigidbody> ();
		//playerHealth = player.GetComponent <PlayerHealth> ();
		//enemyHealth = GetComponent <EnemyHealth> ();
		nav = GetComponent <NavMeshAgent> ();

	}
	
	// not fixed update because not keeping in time with physics
	void Update ()
	{
		if (!doWeSeePlayer()) {
			onPatrol();
		} else {
			nav.SetDestination(player.position);
		}

		// only set the dude's destination if both the player and enemy are alive
//		if(enemyHealth.currentHealth > 0 && playerHealth.currentHealth > 0)
//		{
			// This is where I want to go. Towards the player.
		//	nav.SetDestination (player.position);
		//}
//		else
//		{
			// if one is dead, we don't want to go anywhere, so disable the nav mesh
			//nav.enabled = false;
//		}
	}

	void onPatrol() {
		// Keep moving
		movement.Set(xMovement, 0f, zMovement);
		// so we move by time, not by frame & we move at our speed
		movement = movement.normalized * speed * Time.deltaTime;
		enemyRigidBody.MovePosition(transform.position + movement);
	}

	// if it's time to turn....
	void OnTriggerExit() {
		// Rotate
		//transform.Rotate (transform.rotation.x + 90,transform.rotation.y,transform.rotation.z);

		// Change where we move
		// set x & z movements appropriately

		// Movement Key: (x, z)
		// UP: (0, 1)
		// RIGHT: (1, 0)
		// DOWN: (0, -1)
		// LEFT: (-1, 0)


		switch ((int) xMovement) 
		{
		case 0:
			if (zMovement == 1) {
				xMovement = 1f;
				zMovement = 0f;
			} else {
				xMovement = -1f;
				zMovement = 0f;
			}
			break;
		case 1:
			xMovement = 0f;
			zMovement = -1f;
			break;
		case -1:
			xMovement = 0f;
			zMovement = 1f;
			break;
		default:
			break;
		}
		
	}


	bool doWeSeePlayer() {
		return false;
	}

	void goBackToPatrol() {

	}
}
