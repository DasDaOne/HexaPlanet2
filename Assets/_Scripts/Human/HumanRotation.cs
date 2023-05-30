using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HumanRotation : MonoBehaviour
{
    [SerializeField] private Transform planetTransform;
    
    private Vector3 previousPosition;
    
    private void Update()
    {
        transform.rotation = Quaternion.LookRotation(transform.position - previousPosition, planetTransform.position - transform.position);
        
        previousPosition = transform.position;
    }
}
