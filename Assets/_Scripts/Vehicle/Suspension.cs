using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Suspension : MonoBehaviour
{
    [SerializeField] private float wheelRadius;
    [SerializeField] private float suspensionRadius;
    [SerializeField] private float multiplier;
    [SerializeField] private float adjustments;
    [SerializeField] private Transform raycastOriginPoint;
    [SerializeField] private Transform wheelTransform;

    private void Update()
    {
        Physics.Raycast(wheelTransform.position + raycastOriginPoint.up * 25, -raycastOriginPoint.up, out RaycastHit hit);

        float yCoordinate = (hit.point - transform.position).magnitude;

        yCoordinate /= suspensionRadius;
        
        if (yCoordinate > 1 || yCoordinate < -1)
        {
            return;
        }
        
        float rotationAngle = Mathf.Rad2Deg * Mathf.Asin(yCoordinate);
        
        transform.localRotation = Quaternion.Euler(rotationAngle * multiplier + adjustments, 0, 0);
    }
}
