using UnityEngine;

public class Suspension : MonoBehaviour
{
    [SerializeField] private float wheelRadius;
    [SerializeField] private float multiplier;
    [SerializeField] private Transform raycastOriginPoint;
    [SerializeField] private Transform wheelTransform;
    [SerializeField] private float speed;

    private float suspensionRadius;
    
    private void Start()
    {
        suspensionRadius = (transform.position - wheelTransform.position).magnitude;
    }

    private void Update()
    {
        MoveOriginPoint();

        Physics.Raycast(raycastOriginPoint.position, -raycastOriginPoint.up,
            out RaycastHit hit);

        float xCoordinate = (hit.point - raycastOriginPoint.position).magnitude - wheelRadius;
        
        xCoordinate /= suspensionRadius;

        float rotationAngle;

        Quaternion targetRotation;
        
        if (xCoordinate < 1 && xCoordinate > -1)
        {
            rotationAngle = Mathf.Rad2Deg * Mathf.Acos(xCoordinate);
            targetRotation = Quaternion.Euler(rotationAngle * multiplier, 0, 0);
        }
        else
        {
            targetRotation = Quaternion.identity;
        }

        transform.localRotation = Quaternion.Lerp(transform.localRotation, targetRotation, Time.deltaTime * speed);
    }

    private void MoveOriginPoint()
    {
        raycastOriginPoint.position = wheelTransform.position + raycastOriginPoint.forward * -wheelRadius;
        raycastOriginPoint.localPosition = new Vector3(raycastOriginPoint.localPosition.x, transform.localPosition.y, raycastOriginPoint.localPosition.z);
    }
}
