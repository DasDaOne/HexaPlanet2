using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class PlanetGravity : MonoBehaviour
{
    [SerializeField] private float gravityForce;

    private Rigidbody rigidbody;

    private void Start()
    {
        rigidbody = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        rigidbody.AddForce(-transform.position.normalized * gravityForce, ForceMode.Acceleration);
        // transform.up = transform.position.normalized;
    }
}
