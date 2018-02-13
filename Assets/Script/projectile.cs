using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class projectile : MonoBehaviour {
    public float lifetime;
	int damage = 10;
	PlayerHealth playerHealth;
	// Use this for initialization
	void Start ()
    {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
        lifetime -= Time.deltaTime;
        if (lifetime <= 0)
        {
            Destroy(this.gameObject);
        }
	}

	void OnCollisionEnter (Collider other)
	{
		PlayerHealth P = other.GetComponent<PlayerHealth> ();
		P.TakeDamage (damage);
		Destroy (gameObject);
	}


}
