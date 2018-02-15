using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateArena : MonoBehaviour {

	float timer;


	// Use this for initialization
	void Start () {
		timer = 0;
	}
	
	// Update is called once per frame
	void Update () {
		this.transform.Rotate (new Vector3 (0.0f, 0.1f, 0.0f));


	}
}
