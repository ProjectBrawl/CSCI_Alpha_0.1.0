using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : Singleton<GameManager> {

	List<Character> list_character;
	List<Skill> list_projs;
	List<Buff> list_buffs;

	public Character p1;
	public Character p2;
	public Character p3;
	public Character p4;

	public Text prompt;

	protected GameManager() {} // Limit this to Singleton only and disable constructor.



	void Start(){
		prompt.gameObject.SetActive (false);
	}


	//Update is called every frame.
	void Update()
	{

		if(prompt.gameObject.activeSelf == false)
			if (p1 == null && p2 == null) {
				prompt.gameObject.SetActive (true);
				prompt.text = "Team 2 win!";

			} else if (p3 == null && p4 == null) {
			prompt.gameObject.SetActive (true);
				prompt.text = "Team 1 win!";
			}



	}


}
