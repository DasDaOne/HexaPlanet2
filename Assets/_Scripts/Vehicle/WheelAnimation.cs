using System;
using System.Collections;
using System.Collections.Generic;
using UniRx;
using UnityEngine;

public class WheelAnimation : MonoBehaviour
{
    // [SerializeField] private Transform originPoint;
    // [SerializeField] private float multiplier;
    // [SerializeField] private GameObject trackPrefab;
    // [SerializeField] private float timeBetweenTracks;
    //
    // private Vector3 previousPosition;
    //
    // private float trackTimer;
    //
    // private void Update()
    // {
    //     float velocity = (originPoint.position - previousPosition).magnitude / Time.deltaTime;
    //
    //     if ((previousPosition - originPoint.position + originPoint.forward).magnitude >
    //         (previousPosition - originPoint.position - originPoint.forward).magnitude)
    //         velocity *= -1;
    //     
    //     transform.Rotate(0, 0, velocity * multiplier);
    //
    //     if ((velocity > 0.1f || velocity < -0.01f) && trackTimer <= 0)
    //     {
    //         Instantiate(trackPrefab, transform.position, originPoint.transform.rotation);
    //         trackTimer = timeBetweenTracks;
    //     }
    //
    //     if (trackTimer > 0)
    //     {
    //         trackTimer -= Time.deltaTime;
    //     }
    //     
    //     previousPosition = originPoint.position;
    // }
}
