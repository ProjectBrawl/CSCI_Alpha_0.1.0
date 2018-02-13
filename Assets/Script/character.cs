using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class character : MonoBehaviour {
    public float cooldown;
    float current_cd=0.0f;

    public int id = 1;
	public GameObject other;
	public GameObject projectile;
    Rigidbody rigb;
    Physics phys;
	// Use this for initialization
	void Start ()
    {
        rigb = this.GetComponentInParent<Rigidbody>();
        phys = this.GetComponentInParent<Physics>();
    }

	// Update is called once per frame
	void Update ()
    {
        float x = Input.GetAxis("Horizontal_L_" + id);
        float z = Input.GetAxis("Vertical_L_" + id);
        //Debug.Log(x + ", " + z);
        //if (x >= 0.1f || x <= -0.1f || z >= 0.1f || z <= -0.1f)
        {
            Vector3 f = new Vector3(x, 0.0f, z);
            f *= 20;
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

        current_cd -= Time.deltaTime;

        
        if (Input.GetAxis("Fire_" + id) > 0)
        {
            if (current_cd <=0)
            {
                current_cd = cooldown;
                //Debug.Log(Time.deltaTime + "\t" + current_cd);
				GameObject proj = (GameObject) Instantiate(projectile, this.transform.position + aim, Quaternion.identity);
                Rigidbody proj_rigb = proj.GetComponent<Rigidbody>();
                Vector3 f = aim * 10000 / 40;
                proj_rigb.AddForce(f, ForceMode.Impulse);



            }
        }
		
    }
}
