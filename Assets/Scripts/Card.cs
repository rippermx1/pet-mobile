using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Card", menuName = "ScriptableObjects/Card")]
public class Card : ScriptableObject
{
    public float cardCooldown = 0.5f;
    public string cardName;
    public int cardCost = 1;
    public bool isActive;
    public Texture2D cardIcon;
    public string history;
    public string type;
}
