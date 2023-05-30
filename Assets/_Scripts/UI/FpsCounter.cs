using System;
using TMPro;
using UnityEngine;

public class FpsCounter : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI textField;

    private void Update()
    {
        textField.text = ((int)(1f / Time.unscaledDeltaTime)).ToString();
    }
}
