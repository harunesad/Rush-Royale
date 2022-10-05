using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class DeckChange : MonoBehaviour
{
    public static DeckChange instance;
    public GameObject deck;
    public List<GameObject> DeckList;
    private void Awake()
    {
        instance = this;
    }
    public void DeckSelect(Image Deck)
    {
        if (ButtonClick.instance.newImage != null)
        {
            deck = Deck.gameObject;
            Sprite deckSprite = deck.GetComponent<Image>().sprite;
            Sprite selectSprite = ButtonClick.instance.newImage.GetComponent<Image>().sprite;
            ButtonSelect.instance.useButton.SetActive(false);
            ButtonSelect.instance.infoButton.SetActive(false);
            for (int i = 0; i < DeckList.Count; i++)
            {
                if (DeckList[i].GetComponent<Image>().sprite == ButtonClick.instance.newImage.GetComponent<Image>().sprite)
                {
                    return;
                }
            }
            if (deckSprite != selectSprite)
            {
                deck.name = ButtonClick.instance.newImage.name;
                deck.GetComponent<Image>().sprite = selectSprite;
            }
        }
        else
        {
            GameObject parent = ButtonSelect.instance.useButton.transform.parent.gameObject;
            parent.transform.GetChild(2).gameObject.SetActive(true);
            parent.transform.GetChild(3).gameObject.SetActive(true);
            ButtonSelect.instance.useButton.SetActive(false);
            ButtonSelect.instance.infoButton.SetActive(false);
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
