using UnityEngine;
// Important if we are using new UI components
// Need this import
using UnityEngine.UI;
using System.Collections;

public class UserHealth : MonoBehaviour {

	public int startingHealth = 100;
	public int currentHealth;
	public Slider healthSlider;
	public Image damageImage;
	//public AudioClip deathClip;
	public float flashSpeed = 5f;
	public Color flashColour = new Color(1f, 0f, 0f, 0.1f);
	
	
	//Animator anim; // reference to animator components
	//AudioSource playerAudio;
	UserMovement userMovement; // reference to another script
	bool isDead;
	bool damaged;
	
	
	void Awake ()
	{
		//anim = GetComponent <Animator> ();
		//playerAudio = GetComponent <AudioSource> ();
		userMovement = GetComponent <UserMovement> ();
		//playerShooting = GetComponentInChildren <PlayerShooting> ();
		currentHealth = startingHealth;
	}
	
	
	void Update ()
	{
		if(damaged)
		{
			damageImage.color = flashColour;
		}
		else
		{
			damageImage.color = Color.Lerp (damageImage.color, Color.clear, flashSpeed * Time.deltaTime);
		}
		damaged = false;
	}
	
	
	public void TakeDamage (int amount)
	{
		damaged = true;
		
		currentHealth -= amount;
		
		healthSlider.value = currentHealth;
		
		//playerAudio.Play ();
		
		if(currentHealth <= 0 && !isDead)
		{
			Death ();
		}
	}
	
	
	void Death ()
	{
		isDead = true;

		//anim.SetTrigger ("Die");
		
		//playerAudio.clip = deathClip;
		//playerAudio.Play ();
		
		userMovement.enabled = false;
	}
	
	
	public void RestartLevel ()
	{
		Application.LoadLevel (Application.loadedLevel);
	}
}
