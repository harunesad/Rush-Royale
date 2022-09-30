using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class DeckChange : MonoBehaviour
{
    public static DeckChange instance;
    public GameObject deck;
    public List<Image> DeckList;
    private void Awake()
    {
        instance = this;
    }
    public void DeckSelect(Image Deck)
    {
        deck = Deck.gameObject;
        Sprite deckSprite = deck.GetComponent<Image>().sprite;
        Sprite selectSprite = ButtonClick.instance.newImage.GetComponent<Image>().sprite;
        for (int i = 0; i < DeckList.Count; i++)
        {
            if (DeckList[i].GetComponent<Image>().sprite == ButtonClick.instance.newImage.GetComponent<Image>().sprite)
            {
                return;
            }
        }
        if (deckSprite != selectSprite)
        {
            deck.GetComponent<Image>().sprite = selectSprite;
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
