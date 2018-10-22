using System;
using UnityEngine;

public class PogoStickBody : MonoBehaviour
{
    [SerializeField] float _steeringSpeed = 100f;
    [SerializeField] float _turningSpeed = 5f;

    float _currentMousePos;
    float _previousMousePos;
    
    void Update()
    {
        RespondToSteeringInput();
    }

    private void RespondToSteeringInput()
    {
        float h = Input.GetAxis("Horizontal");
        transform.Rotate(Vector3.back, h * _steeringSpeed * Time.deltaTime);
        float v = Input.GetAxis("Vertical");
        transform.Rotate(Vector3.right, v * _steeringSpeed * Time.deltaTime);

        if (Input.GetMouseButtonDown(0))
        {
            _previousMousePos = Input.mousePosition.x;
        }

        if (Input.GetMouseButton(0))
        {
            _currentMousePos = Input.mousePosition.x;
            var currentSwipe = _currentMousePos - _previousMousePos;
            transform.Rotate(Vector3.up, currentSwipe * _turningSpeed * Time.deltaTime, Space.World);
            _previousMousePos = _currentMousePos;
        }
    }
}
