using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class PlanetGenerator : MonoBehaviour
{
    [SerializeField] private Transform groundParent;

    [SerializeField] private Transform waterParent; 
    
    private List<int> deletedIndexes = new List<int>();
    
    private void Start()
    {
        Application.targetFrameRate = 200;
    
        for (int i = 0; i < groundParent.childCount; i++)
        {
            if (Random.Range(0, 2) == 0)
            {
                deletedIndexes.Add(i);
                Destroy(groundParent.GetChild(i).gameObject);
            }
            else
            {
                Destroy(waterParent.GetChild(i).gameObject);
            }
        }
    }
}
