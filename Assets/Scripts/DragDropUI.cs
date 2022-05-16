using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class DragDropUI : MonoBehaviour, IPointerDownHandler, IDragHandler, IPointerUpHandler
{
    Vector3 offset;
    CanvasGroup canvasGroup;
    public string destinationTag = "DropArea";
    Vector3 initialPosition;

    [HideInInspector] public bool onDrag;
    [HideInInspector] public bool onPointerUp;
    [HideInInspector] public bool onPointerDown;
    public static DragDropUI instance { get; private set; }

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(this);
        }

        if (gameObject.GetComponent<CanvasGroup>() == null)
            gameObject.AddComponent<CanvasGroup>();
        canvasGroup = gameObject.GetComponent<CanvasGroup>();

        initialPosition = transform.position;        
    }

    public void OnDrag(PointerEventData eventData)
    {
        Debug.Log("OnDrag");
        transform.position = Input.mousePosition + offset;

        eventStateHandler(true, false, false);
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        Debug.Log("OnPointerDown");
        offset = transform.position - Input.mousePosition;

        canvasGroup.alpha = 0.5f;
        canvasGroup.blocksRaycasts = false;

        eventStateHandler(false, false, true);
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        Debug.Log("OnPointerUp");
        RaycastResult raycastResult = eventData.pointerCurrentRaycast;
        if (raycastResult.gameObject?.tag == destinationTag)
        {
            Debug.Log("OnPointerUp");
        }
        transform.position = initialPosition;

        canvasGroup.alpha = 1;
        canvasGroup.blocksRaycasts = true;

        eventStateHandler(false, true, false);
    }

    private void eventStateHandler(bool _onDrag, bool _onPointerUp, bool _onPointerDown) {
        onDrag = _onDrag;
        onPointerUp = _onPointerUp;
        onPointerDown = _onPointerDown;
    }
}
