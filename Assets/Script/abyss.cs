using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class abyss : MonoBehaviour {
    public GameObject noticetext;
	// Use this for initialization
	void Start ()
    {
        
	}
	
	// Update is called once per frame
	void Update ()
    {
		
	}

    void OnTriggerEnter(Collider collider)
    {
        switch (collider.gameObject.name)
        {
            case "character1":
                //noticetext.GetComponent<GUIText>().text = "Blue wins!";
                Destroy(collider.gameObject);
                break;
            case "character2":
				Destroy(collider.gameObject);
                break;
            default:
                break;
        }
    }
}
