using System;
using UnityEngine;

public class VehicleMovement : MonoBehaviour
{
    [Header("Movement Parameters")] 
    [SerializeField] private float maxMovementSpeed;
    [SerializeField] private float accelerationSpeed;
    [SerializeField] private float decelerationSpeed;

    [Header("Rotation Parameters")]
    [SerializeField] private float maxRotationSpeed;
    [SerializeField] private float rotationAcceleration;
    [SerializeField] private float rotationDeceleration;

    [Header("Vertical Movement")] 
    [SerializeField] private float heightAboveTile;
    [SerializeField] private float verticalSpeed;
    
    [Header("Other")] 
    [SerializeField] private Transform planetTransform;
    [SerializeField] private Joystick joystick;
    
    private float movementSpeed;
    public float MovementSpeed => movementSpeed;

    private float rotationSpeed;
    public float RotationSpeed => rotationSpeed;

    private void Update()
    {
        Vector2 inputDirections = joystick.Direction;

        if (!planetTransform) return;

        if (joystick.Direction.magnitude > 0.01f)
        {
            Acceleration(inputDirections);
        }
        else
        {
            Deceleration();
        }
        
        transform.RotateAround(planetTransform.position, -transform.right, -movementSpeed);
        transform.Rotate(0, rotationSpeed, 0);
        
        ChangeVerticalPosition();
    }

    private void Acceleration(Vector2 inputDirections)
    {
        movementSpeed = Mathf.Lerp(movementSpeed, maxMovementSpeed * inputDirections.y, accelerationSpeed * Time.deltaTime);
        rotationSpeed = Mathf.Lerp(rotationSpeed, maxRotationSpeed * inputDirections.x, rotationAcceleration * Time.deltaTime);
    }

    private void Deceleration()
    {
        movementSpeed = Mathf.Lerp(movementSpeed, 0, decelerationSpeed * Time.deltaTime);
        rotationSpeed = Mathf.Lerp(rotationSpeed, 0, rotationDeceleration * Time.deltaTime);
    }

    private void ChangeVerticalPosition()
    {
        Vector3 newPos;
        Vector3 upDir = (transform.position - planetTransform.position).normalized;
        
        if (Physics.Raycast(transform.position + upDir * 25, -upDir, out RaycastHit hit))
        {
            newPos = hit.point + upDir * heightAboveTile;
        }
        else
        {
            newPos = planetTransform.position;
        }
        
        transform.position = Vector3.Lerp(transform.position, newPos, verticalSpeed * Time.deltaTime);
    }
}