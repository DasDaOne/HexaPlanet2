using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VehicleDynamicAnimations : MonoBehaviour
{
    // [Header("Pitch")] [Header("RotationAnimations")]
    // [SerializeField] private Transform pitchTransform;    
    // [SerializeField] private float pitchAngleMultiplier;
    // [SerializeField] private float pitchSpeed;
    //
    // [Header("Roll")]
    // [SerializeField] private Transform rollTransform;
    // [SerializeField] private float rollAngleMultiplier;
    // [SerializeField] private float rollSpeed;
    //
    // [Header("Other")]
    // [SerializeField] private VehicleMovement vehicleMovement;
    //
    // [Header("Smoke")] [Header("SmokeAnimations")] 
    // [SerializeField] private Transform[] smokes;
    // [SerializeField] private Vector3 smokeSizeMultiplier;
    //
    // private Vector2 velocity;
    // private Vector2 deltaVelocity;
    // private Vector2 previousVelocity;
    //
    // private void Update()
    // {
    //     GetVelocity();
    //     RotationAnimations();
    //     SmokeAnimations();
    // }
    //
    // private void GetVelocity()
    // {
    //     velocity = new Vector2(vehicleMovement.MovementSpeed, vehicleMovement.RotationSpeed);
    //     deltaVelocity = velocity - previousVelocity;
    //     previousVelocity = velocity;   
    // }
    //
    // private void RotationAnimations()
    // {
    //     Vector3 pitch = new Vector3(Mathf.Lerp(0, deltaVelocity.x * pitchAngleMultiplier, Time.deltaTime * pitchSpeed), 0, 0);
    //     Vector3 roll = new Vector3(0, 0, Mathf.Lerp(0, deltaVelocity.y * rollAngleMultiplier, Time.deltaTime * rollSpeed));
    //     pitchTransform.localEulerAngles = pitch;
    //     rollTransform.localEulerAngles = roll;
    // }
    //
    // private void SmokeAnimations()
    // {
    //     Vector3 smokeSize = Vector3.one + smokeSizeMultiplier * velocity.x;
    //     foreach (Transform smoke in smokes)
    //     {
    //         smoke.localScale = smokeSize;
    //     }
    // }
}
