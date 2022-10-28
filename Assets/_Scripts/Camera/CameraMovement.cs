using System;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    [Header("Target")]
    [SerializeField] private Transform target;
    [SerializeField] private float upwardsOffset;
    [SerializeField] private float backwardsOffset;
    
    [Header("Speed")]
    [SerializeField] private float movementSpeed;
    [SerializeField] private float rotationSpeed;
    
    [Header("Other")]
    [SerializeField] private Transform planetTransform;

    private void Start()
    {
        Application.targetFrameRate = 60;
        
        upwardsOffset = (planetTransform.position - transform.position).z;
        backwardsOffset = (target.position - transform.position).y;
    }

    private void LateUpdate()
    {
        Vector3 targetPosition = planetTransform.position;

        targetPosition += (target.position - planetTransform.position).normalized * upwardsOffset;
        targetPosition -= target.forward * backwardsOffset;
        
        transform.position = Vector3.Lerp(transform.position, targetPosition, movementSpeed * Time.deltaTime);

        Quaternion targetRotation = Quaternion.LookRotation(target.position - transform.position, transform.position - planetTransform.position);
        
        transform.rotation = Quaternion.Lerp(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime); 
    }
}
