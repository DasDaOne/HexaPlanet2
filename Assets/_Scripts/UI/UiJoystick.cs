using System;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UIElements;
using Image = UnityEngine.UI.Image;

[RequireComponent(typeof(Image))]
public class UiJoystick : MonoBehaviour, IDragHandler, IPointerExitHandler, IBeginDragHandler, IEndDragHandler
{
    [SerializeField] private RectTransform controllerTransform;
    
    private RectTransform rectTransform;

    public Action<Vector2> onJoystickDrag;

    private Vector2 dragPosition;

    private bool isDragging;
    
    private void Start()
    {
        rectTransform = transform as RectTransform;
        GetComponent<Image>().alphaHitTestMinimumThreshold = 1;
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        isDragging = true;
    }

    public void OnDrag(PointerEventData eventData)
    {
        if(!isDragging) return;
        
        dragPosition = eventData.position - rectTransform.anchoredPosition;
        controllerTransform.anchoredPosition = eventData.position;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        EndDrag();
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        EndDrag();
    }

    private void EndDrag()
    {
        isDragging = false;

        controllerTransform.anchoredPosition = rectTransform.anchoredPosition;
    }
}
