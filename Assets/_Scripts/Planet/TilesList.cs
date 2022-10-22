using System;
using System.Collections.Generic;
using UnityEngine;

public enum TileName
{
    Stone
}

[CreateAssetMenu(fileName = "All Tiles", menuName = "Planet Generation/All Tiles", order = 51)]
public class TilesList : ScriptableObject 
{
    public List<TileInfo> tiles;
}

[Serializable]
public struct TileInfo
{
    public TileObject thisTile;
    public float chanceOfSpawning;
}