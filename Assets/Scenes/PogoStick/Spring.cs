using UnityEngine;

public class Spring : MonoBehaviour
{
    [SerializeField]
    float _powerMultiplier = 5f;
    [SerializeField]
    private float _springStiffness = 5f;
    [SerializeField]
    GameObject _pogoStick;

    private Rigidbody _pogoStickBody;
    private float _triggerEnterTime;
    private Vector3 _velocityOnTriggerEnter;
    private bool _hasCollided;

    void Start()
    {
        _pogoStickBody = _pogoStick.GetComponent<Rigidbody>();
    }

    private void OnTriggerEnter(Collider other)
    {
        _triggerEnterTime = Time.time;
        _velocityOnTriggerEnter = _pogoStickBody.velocity;
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
        var forceBack = Vector3.Dot(gravitationalForce, _velocityOnTriggerEnter.normalized)
            * -_velocityOnTriggerEnter.normalized * relativeForceMultiplier;
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
        var force = Vector3.Dot(forceUp, (_pogoStickBody.transform.up + normal).normalized) * (_pogoStickBody.transform.up + normal).normalized;
        _pogoStickBody.AddForce(force);
    }
}
