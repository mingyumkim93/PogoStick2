using System;
using UnityEngine;

namespace PogoStick
{
    public class PogoStickBody : MonoBehaviour
    {
        [SerializeField]
        float _steeringSpeed = 100f;
        
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
            float x = Input.GetAxis("Mouse X");
            transform.Rotate(Vector3.up, x * _steeringSpeed * Time.deltaTime, Space.World);
        }
    }
}