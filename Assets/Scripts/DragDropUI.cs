using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class DragDropUI : MonoBehaviour, IPointerDownHandler, IDragHandler, IPointerUpHandler
{
    Vector3 offset;
    CanvasGroup canvasGroup;
    public string destinationTag = "DropArea";
    Vector3 initialPosition;

    void Awake()
    {
        if (gameObject.GetComponent<CanvasGroup>() == null)
            gameObject.AddComponent<CanvasGroup>();
        canvasGroup = gameObject.GetComponent<CanvasGroup>();

        initialPosition = transform.position;        
    }

    public void OnDrag(PointerEventData eventData)
    {
        Debug.Log("OnDrag");
        transform.position = Input.mousePosition + offset;

        CardsController.instance.eventStateHandler(true, false, false);
        CardsController.instance.horizontalLayoutGroup.enabled = false;
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        Debug.Log("OnPointerDown");
        offset = transform.position - Input.mousePosition;

        canvasGroup.alpha = 0.5f;
        canvasGroup.blocksRaycasts = false;

        CardsController.instance.eventStateHandler(false, false, true);
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

        CardsController.instance.eventStateHandler(false, true, false);
        CardsController.instance.horizontalLayoutGroup.enabled = true;

        AbilityUsed();
    }


    #region COOLDOWN
    public GameObject cooldownImage;
    public GameObject cooldownText;
    public float cooldown = 5;
    bool isCooldown = false;
    private void AbilityUsed()
    {
        if (isCooldown)
            return;
        isCooldown = true;
        cooldownImage.SetActive(true);
        cooldownText.SetActive(true);

        cooldownImage.GetComponent<Image>().fillAmount = 1;

        Debug.Log("AbilityUsed");
        StartCoroutine(LerpCooldownValue());
    }

    private IEnumerator LerpCooldownValue()
    {
        float currentTime = 0;
        while (currentTime < cooldown)
        {
            cooldownImage.GetComponent<Image>().fillAmount = Mathf.Lerp(1, 0, currentTime / cooldown);
            
            currentTime += Time.deltaTime;
            cooldownText.GetComponent<TMPro.TMP_Text>().text = currentTime.ToString();
            yield return null;
        }
        cooldownImage.GetComponent<Image>().fillAmount = 0;
        isCooldown = false;

        cooldownImage.SetActive(false);
        cooldownText.SetActive(false);
    }
    #endregion
}
