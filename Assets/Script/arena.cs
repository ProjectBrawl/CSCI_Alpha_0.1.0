using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class arena : MonoBehaviour {
    public float scale;
    public float time_rate;
    float timer;
	// Use this for initialization
	void Start ()
    {
        timer = 0;
    }
	
	// Update is called once per frame
	void Update ()
    {
        timer += Time.deltaTime;

        if (timer >= time_rate)
        {
            timer = 0;
            transform.localScale = new Vector3(
                transform.localScale.x * scale,
                transform.localScale.y * 1,
                transform.localScale.z * scale);
        }
        
	}
}
