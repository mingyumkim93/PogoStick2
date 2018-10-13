using UnityEngine;

public class PogoStick : MonoBehaviour {

    Rigidbody pogoStickBody;
    [SerializeField]
    float steeringSpeed = 100f;
    [SerializeField]
    float powerMultiplier = 2f;
    [SerializeField]
    private float _maxDepth = 0.25f;
    [SerializeField]
    private float _springStiffness = 3f;

    private GameObject _spring;
    private Vector3 _collisionPoint;

    void Start()
    {
        pogoStickBody = GetComponent<Rigidbody>();

        _spring = GameObject.Find("Spring");
    }

    void Update()
    {
        RespondToSteeringInput();
    }

    private void OnCollisionEnter(Collision collision)
    {
        powerMultiplier = 2f;
    }

    private void OnCollisionStay(Collision collision)
    {
        if (Input.GetKey(KeyCode.Space))
            powerMultiplier = 5f;
        UpdateJumpSequence(collision);
    }

    private void UpdateJumpSequence(Collision collision) {
        Vector3 force = pogoStickBody.mass * Physics.gravity * _springStiffness * powerMultiplier ;
        var contact = collision.contacts[0];
        var normal = contact.normal;
        force = Vector3.Dot(force, normal) * normal.normalized;
        force = Vector3.Dot(pogoStickBody.transform.up, force) * force.normalized;
        pogoStickBody.AddForce(-force);
    }

    private void RespondToSteeringInput()
    {
        float h = Input.GetAxis("Horizontal");
        transform.Rotate(Vector3.back, h * steeringSpeed * Time.deltaTime);
        float v = Input.GetAxis("Vertical");
        transform.Rotate(Vector3.right, v * steeringSpeed * Time.deltaTime);

        if (Input.GetKey(KeyCode.LeftArrow))
            transform.Rotate(-Vector3.up, steeringSpeed * Time.deltaTime);
        if (Input.GetKey(KeyCode.RightArrow))
            transform.Rotate(Vector3.up, steeringSpeed * Time.deltaTime);
    }
}
