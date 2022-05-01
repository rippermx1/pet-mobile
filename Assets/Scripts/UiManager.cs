using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UiManager : MonoBehaviour
{
    public static UiManager instance { get; private set; }

    // PET INFO
    // [SerializeField] private Texture2D petIcon;
    [SerializeField] private TMPro.TMP_Text petName;
    [SerializeField] private TMPro.TMP_Text petExperience;
    [SerializeField] private TMPro.TMP_Text petLevel;
    [SerializeField] private TMPro.TMP_Text petEnergy;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            // DontDestroyOnLoad(instance);
            Debug.Log(GameManager.instance.pet);
            petName.text = GameManager.instance.pet.petName;
            petExperience.text = GameManager.instance.pet.petExperience.ToString();
            petLevel.text = GameManager.instance.pet.level.ToString();
            petEnergy.text = GameManager.instance.pet.energy.ToString();
        }
        else {
            Destroy(this);  
        } 

    }

    public void updateExperience(int value) {
        petExperience.text = value.ToString();
    }

    public void updateLevel(int value)
    {
        petLevel.text = value.ToString();
    }

    public void updateEnergy(int value)
    {
        petEnergy.text = value.ToString();
    }
}
