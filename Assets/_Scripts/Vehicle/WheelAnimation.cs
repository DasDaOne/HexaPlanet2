using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WheelAnimation : MonoBehaviour
{
    [SerializeField] private Transform originPoint;
    [SerializeField] private float multiplier;
    
    private Vector3 previousPosition;
    
    private void Update()
    {
        float velocity = (originPoint.position - previousPosition).magnitude / Time.deltaTime;

        if ((previousPosition - originPoint.position + originPoint.forward).magnitude >
            (previousPosition - originPoint.position - originPoint.forward).magnitude)
            velocity *= -1;
        
        transform.Rotate(0, 0, velocity * multiplier);
        
        previousPosition = originPoint.position;
    }
}
