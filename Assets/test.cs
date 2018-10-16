using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class test : MonoBehaviour {

    float springConstant;
    float yVelocity;
    Rigidbody rigidBody;
    

	// Use this for initialization
	void Start () {
        rigidBody = GetComponent<Rigidbody>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnCollisionStay(Collision collision)
    { 
    }
    

}
