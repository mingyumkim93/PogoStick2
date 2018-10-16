using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestB : MonoBehaviour {

    private void OnCollisionEnter(Collision collision)
    {
        print("B collision");
    }

    private void OnTriggerEnter(Collider other)
    {
        print("B trigger");
    }

}
