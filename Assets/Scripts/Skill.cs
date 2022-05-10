using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Skill", menuName = "ScriptableObjects/Skill")]
public class Skill : ScriptableObject
{
    public float skillCooldown = 0.5f;
    public string skillName;
    public bool isActive;
}
