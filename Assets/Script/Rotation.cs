using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotation : MonoBehaviour {


	private int counter = 0;
	private int timer = 0;
	private bool rotate = false;
	
	// Update is called once per frame
	void Update () {
		if (rotate) {
			if (counter != 540) {
				transform.Rotate (Vector3.up * 10 * Time.deltaTime);
				counter += 1;
			} else {
				counter = 0;
				rotate = !rotate;
			}
		} else {
			timer++;
			if (timer == 500) {
				timer = 0;
				rotate = true;
			}
		}
	}
}
