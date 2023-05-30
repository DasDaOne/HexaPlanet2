using UnityEngine;

public class HumanMovement : MonoBehaviour
{
    [Header("Speed")] 
    [SerializeField] private float movementSpeed;
    [SerializeField] private float rotationSpeed; 
    
    [Header("Vertical Movement")] 
    [SerializeField] private float heightAboveTile;
    [SerializeField] private float verticalSpeed;
    
    [Header("Other")] 
    [SerializeField] private Transform planetTransform;
    [SerializeField] private Joystick joystick;
    [SerializeField] private float customColliderLength;
    [SerializeField] private LayerMask raycastMask;
    
    private void Update()
    {
        Vector2 inputDirections = joystick.Direction;

        if (!planetTransform) return;

        if (joystick.Direction.magnitude > 0.01f && ControllerManager.Instance.CurrentController == Controller.Human)
        {
            transform.Rotate(0, rotationSpeed * Time.deltaTime * inputDirections.x, 0);
            
            if(!CheckForCollision())
                transform.RotateAround(planetTransform.position, transform.right, movementSpeed * inputDirections.y * Time.deltaTime);
        }
        
        ChangeVerticalPosition();
    }

    private bool CheckForCollision()
    {
        return Physics.Raycast(transform.position, transform.forward, customColliderLength, raycastMask);
    }

    private void ChangeVerticalPosition()
    {
        Vector3 newPos;
        Vector3 upDir = (transform.position - planetTransform.position).normalized;
        
        if (Physics.Raycast(transform.position + upDir * 25, -upDir, out RaycastHit hit, 100f, raycastMask))
        {
            newPos = hit.point + upDir * heightAboveTile;
        }
        else
        {
            newPos = planetTransform.position;
        }
        
        transform.position = Vector3.Lerp(transform.position, newPos, verticalSpeed * Time.deltaTime);
    }
}
