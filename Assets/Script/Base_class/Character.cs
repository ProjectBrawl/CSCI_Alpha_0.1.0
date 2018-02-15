using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Character : MonoBehaviour {

	public float cooldown;
	float current_cd1=0.0f;
	float current_cd2=0.0f;
	float current_cd3=0.0f;
	float current_cd4=0.0f;

	public int id = 1;
	public GameObject other;
	private int current_health;
	public GameObject projectile;
	Rigidbody rigb;
	Physics phys;

	//basic attributes of a character
	public int team;
	public int hitpoint;
	public float size;
	public int resource;
	public float moving_speed;
	public float jump_height;

	//Coefficients 
	public float speed_coefficient = 1.0f;
	public float damage_coefficient = 1.0f;
	public float damage_taken_coefficient = 1.0f;

	//Skills
	public Skill individual_skill_1;
	public Skill individual_skill_2;
	public Skill team_skill_1;
	public Skill team_skill_2;

	//Buffs
	public Buff buff_1 = null;
	public Buff buff_2 = null;
	public Buff buff_3 = null;
	public Buff buff_4 = null;
	 

	public Text hp;
	public Text mp;

	float res_timer;

	public void instansDeath(){
		current_health -= hitpoint;

	}


	public void onHit(Skill s){
		rigb.AddForce ((transform.position - s.transform.position).normalized * s.pushback_power,ForceMode.Impulse);
		current_health -= (int)(s.hp_damage * damage_taken_coefficient);


		if (s.target_buff_1 != null)
			this.buff_1 = s.target_buff_1;

		//SimpleHealthBar.UpdateBar( "HealthBar", current_health, hitpoint );
		hp.text = current_health.ToString();
	}


	// Use this for initialization
	void Start ()
	{
		rigb = this.GetComponentInParent<Rigidbody>();
		//id = 1;
		current_health = hitpoint; 
		transform.localScale = new Vector3(
			transform.localScale.x * size,
			transform.localScale.y * size,
			transform.localScale.z * size);

		//SimpleHealthBar.UpdateBar( "HealthBar", current_health, hitpoint );
		hp.text = current_health.ToString();
		mp.text = resource.ToString();
	}
		
	// Update is called once per frame
	void Update ()
	{
		mp.text = resource.ToString();
		res_timer += Time.deltaTime;
		if (res_timer > 2.0f) {
			increaseRescource (10);
			res_timer = 0;
		}


		float x = Input.GetAxis("Horizontal_L_" + id);
		float z = Input.GetAxis("Vertical_L_" + id);
		//Debug.Log(x + ", " + z);
		//if (x >= 0.1f || x <= -0.1f || z >= 0.1f || z <= -0.1f)
		{
			Vector3 f = new Vector3(x, 0.0f, z);
			f *= moving_speed;
			rigb.AddForce(f);
		}

		float aim_x = Input.GetAxis("Horizontal_R_" + id);
		float aim_z = Input.GetAxis("Vertical_R_" + id);
		//Debug.Log(aim_x + ", " + aim_z);
		Vector3 aim = new Vector3(aim_x, 0, aim_z);
		aim.Normalize();
		if (aim.magnitude < 0.01f)
		{
			aim = new Vector3(1,0,0);
		}

		current_cd1 -= Time.deltaTime;
		current_cd2 -= Time.deltaTime;

		if (individual_skill_1 != null) {
			if (Input.GetAxis ("Fire_" + id+"_1") > 0) {
				if (current_cd1 <= 0 && resource >= individual_skill_1.cost) {
					resource -= individual_skill_1.cost;
					current_cd1 = individual_skill_1.cooldown;
					//Debug.Log(Time.deltaTime + "\t" + current_cd);
					GameObject proj = (GameObject)Instantiate (individual_skill_1.gameObject, this.transform.position + aim*2, Quaternion.identity);
					Rigidbody proj_rigb = proj.GetComponent<Rigidbody> ();
					Skill skill = proj.GetComponent<Skill> ();
					skill.hp_damage = (int) (skill.hp_damage*(1 + damage_coefficient));

					Vector3 f = aim * 40*individual_skill_1.initial_speed / 40;
					proj_rigb.AddForce (f, ForceMode.Impulse);

				}
			}
		}

		// Used for second fire button
		 if (individual_skill_2 != null) {
			if(Input.GetAxis("Fire_" + id+"_2") > 0)
			{
				if (current_cd2 <=0 && resource >= individual_skill_2.cost)
				{
					current_cd2 = individual_skill_2.cooldown;
					resource -= individual_skill_2.cost;
					//Debug.Log(Time.deltaTime + "\t" + current_cd);
					GameObject proj = (GameObject)Instantiate (individual_skill_2.gameObject, this.transform.position + aim*2, Quaternion.identity);
					Rigidbody proj_rigb = proj.GetComponent<Rigidbody> ();
					Skill skill = proj.GetComponent<Skill> ();
					skill.hp_damage = (int) (skill.hp_damage*(1 + damage_coefficient));

					Vector3 f = aim * 40*individual_skill_1.initial_speed / 40;
					proj_rigb.AddForce (f, ForceMode.Impulse);

				}
			}
		}

		checkDeath ();
	}


	public void increaseRescource(int value){
		resource += value;
	
	}


	private void checkDeath(){
		if (current_health < 0) {


			hp.text = "dead";
			Destroy (gameObject);
		}
	
	}










}
