using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class CameraAndPlayerSpin : MonoBehaviour
{
    [Header("Rotation settings")]
    [SerializeField] private float movementSpeed;
    [SerializeField] private float inertiaSlowDownSpeed;
    [SerializeField] private float inertiaMultiplier;

    [Header("Other")]
    [SerializeField] private Transform planetTransform;
    [SerializeField] private Joystick joystick;

    public bool canMove = true;
    private bool isMoving;

    private List<Vector3> deltas = new List<Vector3>();
    private Vector2 futureRotation;

    private void Update()
    {
        if(!planetTransform) return;

        GetInputs();
    }

    private void GetInputs()
    {
        if (joystick.Direction.magnitude > 0.1f && canMove)
        {
            SpinCamera(joystick.Direction);
        }
        else if (canMove)
            CameraInertia();
    }

    private void SpinCamera(Vector2 deltaPos)
    {
        deltaPos *= movementSpeed * Mathf.Deg2Rad * Time.deltaTime * 100;
        deltaPos.x *= -1;
        
        if (deltaPos.magnitude > 0)
            isMoving = true;
        
        transform.RotateAround(planetTransform.position, transform.up, deltaPos.x);
        transform.RotateAround(planetTransform.position, transform.right, deltaPos.y);

        deltas.Add(deltaPos);

        if (deltas.Count > 5)
            deltas.RemoveAt(0);

        if (deltaPos.magnitude < 0.1f)
            futureRotation = Vector2.zero;
    }

    private void CameraInertia()
    {
        if (isMoving && deltas.Count > 0)
            futureRotation = new Vector2(deltas.Sum(x => x.x), deltas.Sum(y => y.y)) 
                / deltas.Count * inertiaMultiplier;
        else if (!isMoving)
            deltas.Clear();
        
        isMoving = false;
        
        transform.RotateAround(planetTransform.position, transform.up, futureRotation.x);
        transform.RotateAround(planetTransform.position, transform.right, futureRotation.y);
        
        futureRotation = Vector2.Lerp(futureRotation, Vector2.zero, inertiaSlowDownSpeed);
    }
}
