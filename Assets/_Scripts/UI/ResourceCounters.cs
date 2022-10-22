using System;
using TMPro;
using UnityEngine;
using UnityEngine.Events;

public class ResourceCounters : Singleton<ResourceCounters>
{
    [SerializeField] private TextMeshProUGUI debugStoneText;

    public Action<TileName, int> onResourceUpdate;

    private void Awake()
    {
        onResourceUpdate += UpdateResourceText;
    }

    private void UpdateResourceText(TileName resourceName, int amount)
    {
        if (resourceName == TileName.Stone)
        {
            debugStoneText.text = amount.ToString();
        }
        else
        {
            Debug.LogWarning("ты забыл написать функцию для остальных ресурсов");
        }
    }

    private void OnDestroy()
    {
        onResourceUpdate = null;
    }
}
