using UnityEngine;
using UnityEngine.UI;

public class EnterVehicle : MonoBehaviour
{
    [SerializeField] private Button exitButton;
    [SerializeField] private Button enterButton;
    
    [SerializeField] private Transform vehicleTransform;
    
    public void Enter()
    {
        ControllerManager.Instance.ChangeController(Controller.Vehicle);
        
        CameraMovement.Instance.SetTarget(vehicleTransform);
        
        exitButton.gameObject.SetActive(true);
        enterButton.gameObject.SetActive(false);
        
        gameObject.SetActive(false);
    }
}
