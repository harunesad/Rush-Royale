using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DeckUpdate : MonoBehaviour
{
    public SaveObject so;
    [SerializeField] List<GameObject> newDeck;
    void Start()
    {
        so = SaveManager.Load();
        for (int i = 0; i < so.soldiersName.Count; i++)
        {
            newDeck[i] = GameObject.Find(so.soldiersName[i]);
            Sprite newSprite = newDeck[i].GetComponent<Image>().sprite;
            DeckChange.instance.DeckList[i].GetComponent<Image>().sprite = newSprite;
            DeckChange.instance.DeckList[i].name = so.soldiersName[i];
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
