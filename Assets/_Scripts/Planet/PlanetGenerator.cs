using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class PlanetGenerator : MonoBehaviour
{
    [SerializeField] private TilesList tilesList;
    [SerializeField] private Transform groundParent;
    [SerializeField] private float offsetY;
    [SerializeField] private int seed;

    private List<Transform> initializedTiles = new List<Transform>();
    
    private void Start()
    {

        Random.InitState(seed);

        foreach (TileInfo tileInfo in tilesList.tiles)
        {
            foreach (Transform groundTile in groundParent)
            {
                if(initializedTiles.Contains(groundTile)) continue;
                
                if (Random.Range(0, 100) < tileInfo.chanceOfSpawning)
                {
                    InitTile(groundTile.gameObject, tileInfo.thisTile);;
                    initializedTiles.Add(groundTile);
                }
            }
        }
    }

    private void InitTile(GameObject groundTile, TileObject tileObject)
    {
        groundTile.AddComponent<PlacedTileInfo>().thisTileObject = tileObject;
        groundTile.GetComponent<MeshRenderer>().material = tileObject.groundMaterial;

        GameObject additionalGameObject = Instantiate(tileObject.additionalGameObject, groundTile.transform);

        Vector3 centerDirection = (additionalGameObject.transform.position - groundParent.transform.position).normalized;
        
        additionalGameObject.transform.position += centerDirection * offsetY;
        additionalGameObject.transform.rotation = Quaternion.LookRotation(centerDirection);
        additionalGameObject.transform.Rotate(90, 0, 0);
        additionalGameObject.transform.Rotate(0, Random.Range(0f, 360f), 0);

        if (additionalGameObject.TryGetComponent(out PlacedResource resource))
        {
            resource.Init(tileObject);
        }
    }
}
