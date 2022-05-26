using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CardsController : MonoBehaviour
{
    public static CardsController instance { get; private set; }
    [HideInInspector] public bool onDrag;
    [HideInInspector] public bool onPointerUp;
    [HideInInspector] public bool onPointerDown;
    [HideInInspector] public HorizontalLayoutGroup horizontalLayoutGroup;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(this);
        }

        horizontalLayoutGroup = GetComponent<HorizontalLayoutGroup>();
    }
    public void eventStateHandler(bool _onDrag, bool _onPointerUp, bool _onPointerDown)
    {
        onDrag = _onDrag;
        onPointerUp = _onPointerUp;
        onPointerDown = _onPointerDown;
    }
}
