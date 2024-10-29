using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;

public class HelicopterButton : MonoBehaviour, IUpdateSelectedHandler, IPointerDownHandler, IPointerUpHandler
{
    public bool isPressed;
    public float TranslatingFloat;
    public event Action<float> ActionOnHold;
    [SerializeField] private Teleport _teleport;
    public void OnUpdateSelected(BaseEventData data)
    {
        if (isPressed)
        {
            ActionOnHold?.Invoke(TranslatingFloat);
        }
    }
    public void OnPointerDown(PointerEventData data)
    {
        isPressed = true;
        _teleport.EndBrake();
    }
    public void OnPointerUp(PointerEventData data)
    {
        isPressed = false;
        ActionOnHold?.Invoke(0);
    }
}