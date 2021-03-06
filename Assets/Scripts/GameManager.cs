using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance { get; private set; }

    public Pet pet;

    public GameObject catPrefab;

    private GameObject[] playerCards;
    private GameObject[] iaCards;

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
    }

    private IEnumerator Start()
    {
        yield return StartCoroutine(ServerManager.instance.makeRequest(ServerManager.LOCAL_URL + ServerManager.GET_CARDS));

        playerCards = GameObject.FindGameObjectsWithTag("PlayerCards");
        if (playerCards.Length > 0)
        {
            for (int i = 0; i < playerCards.Length; i++)
            {
                Debug.Log(CardCollection.instance.cards[i].cardName);
                playerCards[i].GetComponentInChildren<TMPro.TMP_Text>().text = CardCollection.instance.cards[i].cardName;
            }
        }
    }

    public void feed() {
        if (pet.feed >= 100) pet.feed = 100;
        pet.feed += 10;

        pet.energy += 2;
        if (pet.energy >= 100) pet.energy = 100;
        UiManager.instance.updateEnergy(pet.energy);
    }

    public void play() {
        pet.happiness += 10;
        if (pet.happiness >= 100) pet.happiness = 100;

        pet.energy -= 2;
        if (pet.energy <= 0) pet.energy = 0;
        UiManager.instance.updateEnergy(pet.energy);
    }

    public void workout() {
        pet.petExperience += 10;
        UiManager.instance.updateExperience(pet.petExperience);        
        if (pet.petExperience % 1000 == 0) levelUp();
    }

    public void levelUp() {
        pet.level += 1;
        UiManager.instance.updateLevel(pet.level);        
    }
}
