using UnityEngine;

public enum Controller
{
    Vehicle,
    Human
}

public class ControllerManager : Singleton<ControllerManager>
{
    [SerializeField] private Controller currentController;
    public Controller CurrentController => currentController;

    public void ChangeController(Controller controller)
    {
        currentController = controller;
    }
}
