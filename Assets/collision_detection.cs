using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class collision_detection : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}

    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("Ban bang");

        var policy = new Quotes_Pac();
        policy.type = "root_pac";
        policy.gender = "male";
        policy.age = 30;
        policy.GetQuote();
    }

    // Update is called once per frame
    void Update () {
		
	}
}
    