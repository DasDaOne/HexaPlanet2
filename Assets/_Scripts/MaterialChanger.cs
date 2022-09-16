using UnityEngine;

[ExecuteInEditMode]
public class MaterialChanger : MonoBehaviour
{
    [SerializeField] private Material newMaterial;

    private void OnValidate()
    {
        if(transform.parent.childCount == 0) return;

        foreach (Transform child in transform)
        {
            child.GetComponent<MeshRenderer>().material = newMaterial;
        }
    }
}
