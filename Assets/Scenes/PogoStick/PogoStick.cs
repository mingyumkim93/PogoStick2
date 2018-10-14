using System;
using UnityEngine;

public class PogoStick : MonoBehaviour {

    Rigidbody _pogoStickBody;
    [SerializeField]
    float _steeringSpeed = 100f;
    [SerializeField]
    float _powerMultiplier = 2f;
    [SerializeField]
    private float _maxDepth = 0.25f;
    [SerializeField]
    private float _springStiffness = 3f;

    private float _triggerEnterTime;
    private bool _hasCollided;

    void Start()
    {
        _pogoStickBody = GetComponent<Rigidbody>();
    }

    void Update()
    {
        RespondToSteeringInput();
    }

    private void OnTriggerEnter(Collider other)
    {
        _triggerEnterTime = Time.time;
        _hasCollided = false;
        _powerMultiplier = 5f;
        UpdateSqueeze(other);
    }

    private void OnTriggerStay(Collider other)
    {
        if (Input.GetKey(KeyCode.Space))
            _powerMultiplier = 10f;
        UpdateSqueeze(other);
    }

    private void UpdateSqueeze(Collider other)
    {
        if (_hasCollided) return;
        var gravitationalForce = _pogoStickBody.mass * Physics.gravity;
        var relativeForceMultiplier = (Time.time - _triggerEnterTime) * _springStiffness;
        var forceBack = Vector3.Dot(gravitationalForce, _pogoStickBody.velocity.normalized) 
            * _pogoStickBody.velocity.normalized * relativeForceMultiplier;
        _pogoStickBody.velocity = new Vector3(0f, _pogoStickBody.velocity.y, 0f);
        _pogoStickBody.AddForce(forceBack);
    }

    private void OnCollisionEnter(Collision collision)
    {
        _hasCollided = true;
        UpdateExpand(collision);
    }

    private void OnCollisionStay(Collision collision)
    {
        UpdateExpand(collision);
    }

    private void UpdateExpand(Collision collision)
    {
        var gravitationalForce = _pogoStickBody.mass * Physics.gravity;
        var forceUp = -gravitationalForce * _springStiffness * _powerMultiplier;
        var contact = collision.contacts[0];
        var normal = contact.normal;
        var force = Vector3.Dot(forceUp, normal.normalized) * normal.normalized;
        force = Vector3.Dot(force, _pogoStickBody.transform.up.normalized) * _pogoStickBody.transform.up.normalized;
        _pogoStickBody.AddForce(force);
    }

    private void RespondToSteeringInput()
    {
        float h = Input.GetAxis("Horizontal");
        transform.Rotate(Vector3.back, h * _steeringSpeed * Time.deltaTime);
        float v = Input.GetAxis("Vertical");
        transform.Rotate(Vector3.right, v * _steeringSpeed * Time.deltaTime);

        if (Input.GetKey(KeyCode.LeftArrow))
            transform.Rotate(-Vector3.up, _steeringSpeed * Time.deltaTime, Space.World);
        if (Input.GetKey(KeyCode.RightArrow))
            transform.Rotate(Vector3.up, _steeringSpeed * Time.deltaTime, Space.World);
    }
}
