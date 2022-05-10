using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "CharacterType", menuName = "ScriptableObjects/CharacterType")]
public class CharacterType : ScriptableObject
{
    public string typeName = "Default";
    public string typeDescription;
}
