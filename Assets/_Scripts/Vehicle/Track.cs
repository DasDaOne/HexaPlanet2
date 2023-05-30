using System;
using System.Collections;
using System.Collections.Generic;
using UniRx;
using UnityEditor.Timeline;
using UnityEngine;

public class Track : MonoBehaviour
{
    [SerializeField] private float offset;
    [SerializeField] private float timeUntilDestroy;
    
    private void Start()
    {
        transform.position -= transform.up * offset;
        transform.Rotate(90, 0, 0);
    }

    private void Update()
    {
        if (timeUntilDestroy <= 0)
        {
            Destroy(gameObject);
        }
        
        timeUntilDestroy -= Time.deltaTime;
    }
}
