using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private CharacterType characterType;
    [HideInInspector] public Card[] cards;
    void Start()
    {
        cards = CardCollection.instance.cards;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
