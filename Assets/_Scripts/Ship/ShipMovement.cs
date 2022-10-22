using UnityEngine;

public class ShipMovement : MonoBehaviour
{
    [SerializeField] private Transform planetTransform;
    [SerializeField] private float rotationSpeed;
    
    private Vector3 previousPos;

    private void Update()
    {
        if ((transform.position - previousPos).magnitude > 0.1f)
        {
            Vector3 deltaPos = previousPos - transform.position;
            transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.LookRotation(transform.position - planetTransform.position, deltaPos), Time.deltaTime * rotationSpeed);
        }

        previousPos = transform.position;
    }
}
