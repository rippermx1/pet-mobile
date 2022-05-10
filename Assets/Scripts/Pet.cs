using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Pet", menuName = "ScriptableObjects/Pet")]
public class Pet : ScriptableObject
{
    public string petName = "Default";
    public int level = 1;
    public int petExperience = 0;
    public int health = 100;
    public bool isSleep = false;
    public bool isPlaying = false;
    public int feed = 50; // Go to zero means dead
    public int happiness = 50; // Go to zero means dead
    public int energy = 100;
    public int mana = 100;
    public Skill[] skills;

    // Levels
    // Level 5:  Achieve
    // Level 10: Achieve
    // Level 15: Achieve
    // Level 20: Achieve
    // For each 5 levels, Achieve
}
