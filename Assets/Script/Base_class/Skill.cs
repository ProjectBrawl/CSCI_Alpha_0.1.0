using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skill : MonoBehaviour {

	//skill basic attributes
	public int cost;
	public float cooldown;
	public int hp_damage;
	public float pushback_power;

	public float initial_speed;
	public float size;

	//charging skills
	public bool chargeable;
	public float charge_time;
	public float duration_max;
	public float duration_min;

	//explosive
	public bool explosive;
	public float explode_area;

	//destory on collision
	public bool destory_on_collision;

	//buff
	public Buff self_buff_1;
	public Buff self_buff_2;
	public Buff target_buff_1;
	public Buff target_buff_2;

	public Buff global_buff_1;
	public bool global_buff_1_friendly_fire;
	public Buff global_buff_2;
	public bool global_buff_2_friendly_fire;

	float current_duration = 0;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		current_duration += Time.deltaTime;
		if(current_duration>duration_max)
			Destroy (this.gameObject);

	}

	void OnCollisionEnter(Collision col) {

		if (col.gameObject.tag.Equals("Character")) {
			Character c = col.gameObject.GetComponent<Character> ();

			c.onHit (this);

			if (destory_on_collision)
				Destroy (this.gameObject);
		}
	}

	void OnTriggerEnter(Collider col) {

		if (col.gameObject.tag.Equals("Character")) {
			Character c = col.gameObject.GetComponent<Character> ();

			c.onHit (this);

			if (destory_on_collision)
				Destroy (this.gameObject);
		}
	}


}
