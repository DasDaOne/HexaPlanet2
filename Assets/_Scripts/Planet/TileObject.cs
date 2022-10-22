using UnityEngine;

[CreateAssetMenu(fileName = "Tile Object", menuName = "Planet Generation/Tile Object", order = 51)]
public class TileObject : ScriptableObject 
{
    public TileName tileName;
    public Material groundMaterial;
    
    public GameObject additionalGameObject;
    public Vector2Int resourceAmountRange;
    public float timeToMineState;
    public float timeToRecover;
}