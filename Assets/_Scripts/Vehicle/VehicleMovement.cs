using System;
using UnityEngine;

public class VehicleMovement : MonoBehaviour
{
    [SerializeField] private Transform planetTransform;
    [SerializeField] private float heightAboveTile;
    [SerializeField] private float upMovementSpeed;
    [SerializeField] private float rotationSpeed;
    [SerializeField] private Joystick joystick;
    
    [SerializeField] private WheelAnimation[] wheels;
    
    private Vector3 previousPos;

    private void Update()
    {
        Vector3 deltaPos = previousPos - transform.position;

        Vector3 up = (transform.position - planetTransform.position).normalized;

        if (joystick.Direction.magnitude > 0.1f)
        {
            transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.LookRotation(deltaPos, up), Time.deltaTime * rotationSpeed);
            foreach (WheelAnimation wheel in wheels)
            {
                wheel.speed = deltaPos.magnitude;
            }
        }

        if (Physics.Raycast(transform.position + up * 50, -up, out RaycastHit hit))
        {
            transform.position = Vector3.Lerp(transform.position, hit.point + up * heightAboveTile, upMovementSpeed * Time.deltaTime);
        }

        previousPos = transform.position;
    }
}
