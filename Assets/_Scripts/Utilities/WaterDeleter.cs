using UnityEngine;

public class WaterDeleter : MonoBehaviour
{
    [SerializeField] private Transform waterParent;
    [SerializeField] private LayerMask layerMask;
    
    private void Start()
    {
        if(!waterParent) return;
        foreach (Transform waterTile in waterParent)
        {
            if (Physics.Raycast(waterParent.position, waterTile.position - waterParent.position, layerMask))
                Destroy(waterTile.gameObject);
        }
    }
}
