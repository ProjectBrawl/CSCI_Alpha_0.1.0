using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Buff : MonoBehaviour {

	/* 
		Use string as token to find the attributes.

		hp - hitpoint; (+/-)
		res - resources; (+/-)
		spd - moving speed; (+/-)
		jump - jump height; (+/-)
		spd_coe - moving speed coefficient; (*)
		dmg_coe - damage coefficient; (*)
		dmg_tkn_coe - damage taken coefficient; (*)
	*/
	public bool isBuff;

	public float duration;
	public bool stackable;
	public int current_stack;
	public int max_stack;

	public string effect_1;
	public float value_1;

	public string effect_2;
	public float value_2;

	public string effect_3;
	public float value_3;

	public string effect_4;
	public float value_4;

	public string effect_5;
	public float value_5;


	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
