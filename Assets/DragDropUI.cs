using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class DragDropUI : MonoBehaviour, IPointerDownHandler, IDragHandler, IPointerUpHandler
{
    Vector3 offset;
    CanvasGroup canvasGroup;
    public string destinationTag = "DropArea";

    void Awake()
    {
        /*if (gameObject.GetComponent<CanvasGroup>() == null)
            gameObject.AddComponent<CanvasGroup>();
        canvasGroup = gameObject.GetComponent<CanvasGroup>();*/
    }

    public void OnDrag(PointerEventData eventData)
    {
        Debug.Log("OnDrag");
        transform.position = Input.mousePosition + offset;
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        Debug.Log("OnPointerDown");
        offset = transform.position - Input.mousePosition;
        canvasGroup.alpha = 0.5f;
        canvasGroup.blocksRaycasts = false;
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        Debug.Log("OnPointerUp");
        RaycastResult raycastResult = eventData.pointerCurrentRaycast;
        if (raycastResult.gameObject?.tag == destinationTag)
        {
            transform.position = raycastResult.gameObject.transform.position;
        }
        canvasGroup.alpha = 1;
        canvasGroup.blocksRaycasts = true;
    }
}
