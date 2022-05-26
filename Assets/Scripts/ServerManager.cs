using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class ServerManager : MonoBehaviour
{
    public static ServerManager instance { get; private set; }


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
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public const string DEVELOP_URL = "https://pet-mobile-backend.herokuapp.com/";
    public const string LOCAL_URL = "http://127.0.0.1:8000/";
    public const string GET_CARDS = "cards";

    public IEnumerator makeRequest(string uri)
    {
        using (UnityWebRequest request = UnityWebRequest.Get(uri))
        {
            yield return request.SendWebRequest();
            if (UnityWebRequest.Result.ConnectionError == request.result)
            {
                Debug.LogError(request.error);
            }
            else
            {
                Debug.Log("Request OK");
                print(request.downloadHandler.text);
                
                var response = JsonUtility.FromJson<CardList>(request.downloadHandler.text);
                for (int i = 0; i < response.cards.Length; i++)
                {
                    Card minion = ScriptableObject.CreateInstance<Card>();
                    minion.cardName = response.cards[i].name;
                    minion.price = response.cards[i].price;
                    CardCollection.instance.cards[i] = minion;
                }                
            }
        }
    }

    [Serializable]
    public class ICard
    {
        public string name;
        public string description;
        public float price;
        public string is_available;
        public string type;
        public int attack;
        public int attack_range;
        public int move_speed;
        public int damage;
        public int attack_speed;
        public int level;
        public int exp_left;
        public int health;
        public int invocation_cost;
        public int attack_movement;
        public int attack_area;
    }

    [Serializable]
    public class CardList
    {
        public ICard[] cards;
    }
}
