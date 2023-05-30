using System;
using UnityEngine;

public class VehicleMovement : MonoBehaviour
{
    [Header("Parameters")] 
    [SerializeField] private float motorForce;
    [SerializeField] private float maxSteeringAngle;
    [SerializeField] private float brakeForce;

    [Header("Wheel Colliders")]
    [SerializeField] private WheelCollider frontLeftWheelCollider;
    [SerializeField] private WheelCollider frontRightWheelCollider;
    [SerializeField] private WheelCollider rearLeftWheelCollider;
    [SerializeField] private WheelCollider rearRightWheelCollider;

    [Header("Wheel Transforms")]
    [SerializeField] private Transform frontLeftWheelTransform;
    [SerializeField] private Transform frontRightWheelTransform;
    [SerializeField] private Transform rearLeftWheelTransform;
    [SerializeField] private Transform rearRightWheelTransform;
    
    [Header("Other")] 
    [SerializeField] private Joystick joystick;
    
    private Vector2 inputs;
    
    private void FixedUpdate()
    {
        GetInput();
        Motor();
        Steering();
        Brakes();
        UpdateWheels();
    }

    private void GetInput()
    {
        inputs = joystick.Direction;
    }

    private void Motor()
    {
        float force = inputs.y * motorForce;
        frontLeftWheelCollider.motorTorque = force;
        frontRightWheelCollider.motorTorque = force;
        rearLeftWheelCollider.motorTorque = force;
        rearRightWheelCollider.motorTorque = force;
    }

    private void Steering()
    {
        float steerAngle = inputs.x * maxSteeringAngle;
        frontLeftWheelCollider.steerAngle = steerAngle;
        frontRightWheelCollider.steerAngle = steerAngle;
        rearLeftWheelCollider.steerAngle = -steerAngle;
        rearRightWheelCollider.steerAngle = -steerAngle;
    }

    private void Brakes()
    {
        float currentBrakeForce = Mathf.Abs(inputs.y) < 0.05f ? brakeForce : 0;
        frontLeftWheelCollider.brakeTorque = currentBrakeForce;
        frontRightWheelCollider.brakeTorque = currentBrakeForce;
        rearLeftWheelCollider.brakeTorque = currentBrakeForce;
        rearRightWheelCollider.brakeTorque = currentBrakeForce;
    }

    private void UpdateWheels()
    {
        UpdateSingleWheel(frontLeftWheelCollider, frontLeftWheelTransform);
        UpdateSingleWheel(frontRightWheelCollider, frontRightWheelTransform);
        UpdateSingleWheel(rearLeftWheelCollider, rearLeftWheelTransform);
        UpdateSingleWheel(rearRightWheelCollider, rearRightWheelTransform);
    }

    private void UpdateSingleWheel(WheelCollider wheelCollider, Transform wheelTransform)
    {
        wheelCollider.GetWorldPose(out Vector3 position, out Quaternion rotation);
        wheelTransform.rotation = rotation;
        wheelTransform.position = position;
    }

    // [Header("Movement Parameters")] 
    // [SerializeField] private float maxMovementSpeed;
    // [SerializeField] private float accelerationSpeed;
    // [SerializeField] private float decelerationSpeed;
    //
    // [Header("Rotation Parameters")]
    // [SerializeField] private float maxRotationSpeed;
    // [SerializeField] private float rotationAcceleration;
    // [SerializeField] private float rotationDeceleration;
    //
    // [Header("Vertical Movement")] 
    // [SerializeField] private float heightAboveTile;
    // [SerializeField] private float verticalSpeed;
    //
    // [Header("Other")] 
    // [SerializeField] private Transform planetTransform;
    // [SerializeField] private Joystick joystick;
    // [SerializeField] private LayerMask raycastMask;
    //
    // private float movementSpeed;
    // public float MovementSpeed => movementSpeed;
    //
    // private float rotationSpeed;
    // public float RotationSpeed => rotationSpeed;
    //
    // private void Update()
    // {
    //     Vector2 inputDirections = joystick.Direction;
    //
    //     if (!planetTransform) return;
    //
    //     if (joystick.Direction.magnitude > 0.01f && ControllerManager.Instance.CurrentController == Controller.Vehicle)
    //     {
    //         Acceleration(inputDirections);
    //     }
    //     else
    //     {
    //         Deceleration();
    //     }
    //     
    //     transform.RotateAround(planetTransform.position, transform.right, movementSpeed);
    //     transform.Rotate(0, rotationSpeed, 0);
    //         
    //     ChangeVerticalPosition();
    // }
    //
    // private void Acceleration(Vector2 inputDirections)
    // {
    //     movementSpeed = Mathf.Lerp(movementSpeed, maxMovementSpeed * inputDirections.y, accelerationSpeed * Time.deltaTime);
    //     rotationSpeed = Mathf.Lerp(rotationSpeed, maxRotationSpeed * inputDirections.x, rotationAcceleration * Time.deltaTime);
    // }
    //
    // private void Deceleration()
    // {
    //     movementSpeed = Mathf.Lerp(movementSpeed, 0, decelerationSpeed * Time.deltaTime);
    //     rotationSpeed = Mathf.Lerp(rotationSpeed, 0, rotationDeceleration * Time.deltaTime);
    // }
    //
    // private void ChangeVerticalPosition()
    // {
    //     Vector3 newPos;
    //     Vector3 upDir = (transform.position - planetTransform.position).normalized;
    //     
    //     if (Physics.Raycast(transform.position + upDir * 25, -upDir, out RaycastHit hit, 100f, raycastMask))
    //     {
    //         newPos = hit.point + upDir * heightAboveTile;
    //     }
    //     else
    //     {
    //         newPos = planetTransform.position;
    //     }
    //     
    //     transform.position = Vector3.Lerp(transform.position, newPos, verticalSpeed * Time.deltaTime);
    // }
}