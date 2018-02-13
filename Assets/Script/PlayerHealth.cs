using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class PlayerHealth : MonoBehaviour
{
	public float startingHealth = 10000f;                            // The amount of health the player starts the game with.
	public float currentHealth;                                   // The current health the player has.
	public Image HealthBar;                                 // Reference to the UI's health bar.                                 // Reference to an image to flash on the screen on being hurt.

	void Awake ()
	{

		// Set the initial health of the player.
		currentHealth = startingHealth;
	}
	void Update ()
	{
		TakeDamage (1f);
	}
	public void TakeDamage (float amount)
	{
		currentHealth -= amount;
		HealthBar.fillAmount = currentHealth / startingHealth;
		if(currentHealth <= 0)
		{
			Death ();
		}
	}


	void Death ()
	{
		Destroy (this.gameObject);
	}       
}