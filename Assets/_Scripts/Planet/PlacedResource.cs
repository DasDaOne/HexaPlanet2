using System;
using UniRx;
using UnityEngine;
using UnityEngine.UI;
using Random = UnityEngine.Random;

public class PlacedResource : MonoBehaviour
{
    [SerializeField] private GameObject[] models = new GameObject[3];
    [SerializeField] private Image recoveryImage;
    
    private const int DefaultLayer = 0;
    private const int ResourceLayer = 7;
    
    private int currentState = 2;

    private TileObject tileObject;
    private int resourceAmount;

    private float recoveryTimer;
    
    public float timeToMine => tileObject.timeToMineState;

    public void Init(TileObject tileObject)
    {
        this.tileObject = tileObject;
        resourceAmount = Random.Range(tileObject.resourceAmountRange.x, tileObject.resourceAmountRange.y);
    }

    private void FixedUpdate()
    {
        if(recoveryTimer <= 0)
            return;

        recoveryTimer -= Time.fixedDeltaTime;

        recoveryImage.fillAmount = recoveryTimer / tileObject.timeToRecover;

        if (recoveryTimer <= 0)
        {
            currentState = 2;
            ChangeState();
        }
    }

    private void ChangeState()
    {
        foreach (GameObject model in models)
        {
            model.SetActive(false);
        }
        
        models[currentState].SetActive(true);
        
        if (currentState == 0)
        {
            gameObject.layer = DefaultLayer;
            recoveryTimer = tileObject.timeToRecover;
        }
        else
            gameObject.layer = ResourceLayer;
    }

    public void Mine()
    {
        ResourceManager.Instance.AddResource(tileObject.tileName, resourceAmount / currentState);
        
        currentState -= 1;
        
        ChangeState();
    }
}