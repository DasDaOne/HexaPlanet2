using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WheelAnimation : MonoBehaviour
{
    [SerializeField] private float speedMultiplier;
    [SerializeField] private float deceleration;
    
    [HideInInspector] public float speed;

    private void Update()
    {
        transform.Rotate(0, 0, -speed * speedMultiplier);
        speed -= Time.deltaTime * deceleration;
        speed = Mathf.Clamp(speed, 0, 100);
    }
}
