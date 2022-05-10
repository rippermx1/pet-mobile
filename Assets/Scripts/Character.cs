using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Character", menuName = "ScriptableObjects/Character")]
public class Character : ScriptableObject
{
    public string characterName;
    public string characterLevel;
    public int characterDamage;
    public int characterHealth;
    public int characterExperience;
}
