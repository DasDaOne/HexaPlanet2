using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResourceManager : Singleton<ResourceManager>
{
    [SerializeField] private Dictionary<TileName, int> resources = new Dictionary<TileName, int>();
    [SerializeField] private TilesList allTiles;
    
    private void Awake()
    {
        foreach (TileInfo tileInfo in allTiles.tiles)
        {
            resources.Add(tileInfo.thisTile.tileName, 0);
        }
    }

    public void AddResource(TileName resourceName, int amount)
    {
        resources[resourceName] += amount;
        ResourceCounters.Instance.onResourceUpdate?.Invoke(resourceName, resources[resourceName]);
    }
    
    public void SubtractResource(TileName resourceName, int amount)
    {
        resources[resourceName] -= amount;
        ResourceCounters.Instance.onResourceUpdate?.Invoke(resourceName, resources[resourceName]);
    }
}
