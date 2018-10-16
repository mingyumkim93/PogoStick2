using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class testest : MonoBehaviour {

    private void OnCollisionEnter(Collision collision)
    {
        print("collision");
    }

    private void OnTriggerEnter(Collider other)
    {
        print("trigger");
    }
}
