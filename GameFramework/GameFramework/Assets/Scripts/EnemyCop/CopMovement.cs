using UnityEngine;
using System.Collections;

public class CopMovement : MonoBehaviour {

	public int maxStepCounter;
	public float xMovement;
	public float zMovement;
	public int speed;

	// what the enemy is moving toward
	Transform player;
	//PlayerHealth playerHealth;
	//EnemyHealth enemyHealth;
	NavMeshAgent nav;
	Vector3 movement;
	Rigidbody enemyRigidBody;
	int currentStepCounter;
	
	void Awake ()
	{
		// where the player is
		player = GameObject.FindGameObjectWithTag ("Player").transform; 
		enemyRigidBody = GetComponent<Rigidbody> ();
		//playerHealth = player.GetComponent <PlayerHealth> ();
		//enemyHealth = GetComponent <EnemyHealth> ();
		nav = GetComponent <NavMeshAgent> ();
		currentStepCounter = 0;

	}
	
	// not fixed update because not keeping in time with physics
	void Update ()
	{
		if (doWeSeePlayer()) {
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
		// if it's time to turn....
		if (currentStepCounter >= maxStepCounter) {
			// Rotate
			//transform.Rotate (transform.rotation.x + 90,transform.rotation.y,transform.rotation.z);
			// Reset currentStepCounter
			currentStepCounter = 0;
			// set x & z movements
			xMovement = 1f;
			zMovement = 0f;

		}
		// Keep moving
		movement.Set(xMovement, 0f, zMovement);
		movement = movement.normalized * speed * Time.deltaTime;
		enemyRigidBody.MovePosition(transform.position + movement);
		currentStepCounter++;
	}

	bool doWeSeePlayer() {
		return true;
	}

	void goBackToPatrol() {

	}
}
