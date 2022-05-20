using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardCollection : MonoBehaviour
{
    public static CardCollection instance { get; private set; }
    public Card[] cards;

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

        // Test Cards
        loadTestMinions();
    }

    public void loadTestMinions() {
        for (int i = 0; i < 5; i++)
        {
            Card minion = ScriptableObject.CreateInstance<Card>();
            minion.cardName = "Minion " + i;
            minion.cardCost = 10;
            minion.history = "Minion TEST " + i;
            cards[i] = minion;
            Debug.Log(cards[i]);
        }
    }

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
