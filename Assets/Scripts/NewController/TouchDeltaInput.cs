using UnityEngine;
using UnityEngine.EventSystems;

public class TouchDeltaInput : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    public Vector2 TouchDelta { get; private set; }

    private Vector2 oldPointer;

    private int pointerID;

    private bool isPressed;

    public static TouchDeltaInput instance;

    private void Awake()
    {
        instance = this;
    }
    void FixedUpdate()
    {
        Vector2 completedDelta = Vector2.zero;
        if(!blockXdelta)
        {
            completedDelta.x = blockYdelta ? 0.5f : 1;
        }
        if(!blockYdelta)
        {
            completedDelta.y = 1;
        }

        if (isPressed && enabled)
        {
            if (pointerID >= 0 && pointerID < Input.touches.Length)
            {
                TouchDelta = Input.touches[pointerID].deltaPosition * completedDelta;
                oldPointer = Input.touches[pointerID].position;
            }
            else
            {
                TouchDelta = (new Vector2(Input.mousePosition.x, Input.mousePosition.y) - oldPointer) * completedDelta;
                oldPointer = Input.mousePosition;
            }
        }
        else
        {
            TouchDelta = new Vector2();
        }
    }
    public bool blockXdelta;
    public bool blockYdelta;
    public void OnPointerDown(PointerEventData eventData)
    {
        isPressed = true;
        pointerID = eventData.pointerId;
        oldPointer = eventData.position;
    }
    public void OnPointerUp(PointerEventData eventData)
    {
        isPressed = false;
    }
}