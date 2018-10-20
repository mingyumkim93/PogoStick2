using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotatingCube : MonoBehaviour {
    
    [SerializeField] float rotatingPeriod = 30f;
    public enum RotatingAxis {Up, Forward, Right}
    public RotatingAxis rotatingAxis;
    
    void Update () {
        if(rotatingAxis == RotatingAxis.Up)
            transform.Rotate(Vector3.up, Time.deltaTime * rotatingPeriod);
        if(rotatingAxis == RotatingAxis.Forward)
            transform.Rotate(Vector3.forward, Time.deltaTime * rotatingPeriod);
        if (rotatingAxis == RotatingAxis.Right)
            transform.Rotate(Vector3.right, Time.deltaTime * rotatingPeriod);
    }
}
