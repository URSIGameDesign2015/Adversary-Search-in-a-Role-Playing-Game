using UnityEngine;
using System.Collections;

public class CopAttack : MonoBehaviour {

	public float timeBetweenAttacks = 0.5f;
	public int attackDamage = 10;
	
	
	//Animator anim;
	GameObject player;
	UserHealth playerHealth;
	//EnemyHealth enemyHealth;
	bool playerInRange;
	float timer;
	CopMovement copMovement;
	
	
	void Awake ()
	{
		// do it here because its expensive
		player = GameObject.FindGameObjectWithTag ("Player");
		playerHealth = player.GetComponent <UserHealth> ();
		//enemyHealth = GetComponent<EnemyHealth>();
		copMovement = GetComponent<CopMovement>();
		//anim = GetComponent <Animator> ();
	}
	
	
	void OnTriggerEnter (Collider other)
	{
		if(other.gameObject == player)
		{
			playerInRange = true;
		}
	}
	
	
	void OnTriggerExit (Collider other)
	{
		if(other.gameObject == player)
		{
			playerInRange = false;
		}
	}
	
	
	void Update ()
	{
		timer += Time.deltaTime;
		
		if(timer >= timeBetweenAttacks && playerInRange /*&& enemyHealth.currentHealth > 0*/)
		{
			Attack ();
		}
		
		if(playerHealth.currentHealth <= 0)
		{
			copMovement.enabled = false;
			//anim.SetTrigger ("PlayerDead");
		}
	}
	
	
	void Attack ()
	{
		timer = 0f;
		
		if(playerHealth.currentHealth > 0)
		{
			playerHealth.TakeDamage (attackDamage);
		}
	}
}
