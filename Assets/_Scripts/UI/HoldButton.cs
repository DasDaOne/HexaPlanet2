using System;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class HoldButton : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    [SerializeField] private Color defaultColor = Color.white;
    [SerializeField] private Color holdColor = new Color(0.9f, 0.9f, 0.9f);

    [Serializable]
    private class ButtonEvent : UnityEvent {}
    
    [SerializeField] private ButtonEvent onClick = new ButtonEvent();
    [SerializeField] private ButtonEvent onRelease = new ButtonEvent();

    private Image image;
    
    private void OnValidate()
    {
        image = GetComponent<Image>();
        image.color = defaultColor;
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        onClick?.Invoke();
        image.color = holdColor;
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        onRelease?.Invoke();
        image.color = defaultColor;
    }

    private void OnDisable()
    {
        onRelease?.Invoke();
        image.color = defaultColor;
    }
}
