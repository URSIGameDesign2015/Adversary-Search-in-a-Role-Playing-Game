using UnityEngine;
using System.Collections;

public class CopMovement : MonoBehaviour {

	// TO DO:
	// - Create police paths with box collider check points (navigation)
	// - Raycasting; so we can see the player
	//       -- if you can get the tag, check if it is "player"
	// - How do we go back to patrol area? -- go back to building GameObject? or box collider
 	// - How do we go back to patrolling? 
	//       -- have a bool that says if we are patrolling or not
	//       -- Initially & OnTriggerEnter --> we are patrolling 
	// - Create a non-player character that follows the player character?
	//       -- make the sidekick a child (in unity terms) of the player

	public int speed;
	public Transform[] checkpoints;

	// what the enemy is moving toward
	Transform playerTransform;
	Transform enemyTransform;
	//PlayerHealth playerHealth;
	//EnemyHealth enemyHealth;
	NavMeshAgent nav;
	int checkpointIndex;
	bool areWeFollowingPlayer;

	// for testing
	int counter = 0;

	void Awake ()
	{
		// where the player is
		playerTransform = GameObject.FindGameObjectWithTag ("Player").transform; 
		enemyTransform = GetComponent<Transform> ();
		//playerHealth = player.GetComponent <PlayerHealth> ();
		//enemyHealth = GetComponent <EnemyHealth> ();
		areWeFollowingPlayer = false;
		nav = GetComponent <NavMeshAgent> ();
		OnTriggerEnter ();

	}
	
	// not fixed update because not keeping in time with physics
	void Update ()
	{
		// if we see the player, then follow the player
		if (doWeSeePlayer ()) {
			followPlayer ();
		} 
		// if we were just following the player, but don't see the player anymore
		// go back on patrol
		else if (areWeFollowingPlayer) {
			goBackOnPatrol();
		} 
		// if we didn't see the player and are not following the player,
		// then we are on patrol, which is implemented with the onTrigger stuff
		// so we don't need to do anything.
		else {

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

	void followPlayer() {
		areWeFollowingPlayer = true;
		nav.SetDestination(playerTransform.position);
	}

	void goBackOnPatrol() {
		areWeFollowingPlayer = false;
		int goToCheckpoint = -1;
		float minimumDistance = 100000000;
		// see which checkpoint we are closest to and set our destination to that checkpoint
		// using for instead of foreach so we can set the checkpointIndex too
		for (int i = 0; i < checkpoints.Length; i++) {
			// get the distance from the enemy player
			float distance = Vector3.Distance(checkpoints[i].position, enemyTransform.position);
			// if less than minimumDistance, then make the checkpoint the one we go to. 
			Debug.Log (distance);
			if (distance < minimumDistance) {
				minimumDistance = distance;
				goToCheckpoint = i;
			}
		}
		// if two checkpoints are equally distance from each other, then only the first
		// will be taken, but that's okay because this is an approximation. 
		checkpointIndex = goToCheckpoint;
		nav.SetDestination (checkpoints [checkpointIndex].position);
	}

	// if it's time to turn....
	void OnTriggerEnter() {
		// Rotate
		//transform.Rotate (transform.rotation.x + 90,transform.rotation.y,transform.rotation.z);
			// When we enter a collider, set destination to the next collider's position
			if (checkpointIndex >= checkpoints.Length) {
				checkpointIndex = 0;
			}

			// set next destination
			Debug.Log (checkpointIndex);
			nav.SetDestination (checkpoints [checkpointIndex].position);

			checkpointIndex++;

	}

	bool doWeSeePlayer() {
		counter++;
		return counter < 50;
	}


	// Old Comments:
	// Change where we move
	// set x & z movements appropriately
	
	// Movement Key: (x, z)
	// UP: (0, 1)
	// RIGHT: (1, 0)
	// DOWN: (0, -1)
	// LEFT: (-1, 0)
	
	
	//		switch ((int) xMovement) 
	//		{
	//		case 0:
	//			if (zMovement == 1) {
	//				xMovement = 1f;
	//				zMovement = 0f;
	//			} else {
	//				xMovement = -1f;
	//				zMovement = 0f;
	//			}
	//			break;
	//		case 1:
	//			xMovement = 0f;
	//			zMovement = -1f;
	//			break;
	//		case -1:
	//			xMovement = 0f;
	//			zMovement = 1f;
	//			break;
	//		default:
	//			break;
	//		}

}
