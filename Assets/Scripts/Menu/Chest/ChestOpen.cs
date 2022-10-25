using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using TMPro;

public class ChestOpen : MonoBehaviour, IPointerDownHandler
{
    public ChestMode chestMode;
    public int chestProgress;
    public int chestNumber;
    int randomCoinCommon;
    int randomCoinRare;
    int randomCoinEpic;
    int coinCommon;
    int coinRare;
    int coinEpic;
    public enum ChestMode
    {
        Common,
        Rare,
        Epic
    }
    void Start()
    {
        Debug.Log(PlayerPrefs.GetInt("Coin"));
        if (PlayerPrefs.GetInt("Coin") >= chestProgress)
        {
            gameObject.transform.GetChild(0).gameObject.SetActive(false);
        }
        if (Items.item.chestNumber > chestNumber)
        {
            gameObject.GetComponent<Image>().color = new Color(1, 1, 1, 0.25f);
        }
    }
    void Update()
    {

    }
    public void ChestModeOpen()
    {
        if (gameObject.GetComponent<Image>().color.a > 0.5f && PlayerPrefs.GetInt("Coin") >= chestProgress)
        {
            gameObject.GetComponent<Image>().color = new Color(1, 1, 1, 0.25f);

            switch (chestMode)
            {
                case ChestMode.Common:
                    ChestCards.Instance.UpgradeCards(true, false, false);
                    ChestCards.Instance.Common();
                    Items.item.ChestCoin(5, 10, "Coin");
                    Items.item.crystalAddText.gameObject.SetActive(false);
                    //SaveChestNumber();
                    break;
                case ChestMode.Rare:
                    ChestCards.Instance.UpgradeCards(true, true, false);
                    ChestCards.Instance.Common();
                    ChestCards.Instance.Rare();
                    Items.item.ChestCoin(15, 20, "Coin");
                    Items.item.crystalAddText.gameObject.SetActive(true);
                    Items.item.ChestCrystal(3, 5, "Crystal");
                    SaveChestNumber();
                    break;
                case ChestMode.Epic:
                    ChestCards.Instance.UpgradeCards(true, true, true);    
                    ChestCards.Instance.Common();
                    ChestCards.Instance.Rare();
                    ChestCards.Instance.Epic();
                    Items.item.ChestCoin(25, 40, "Coin");
                    Items.item.crystalAddText.gameObject.SetActive(true);
                    Items.item.ChestCrystal(5, 10, "Crystal");
                    SaveChestNumber();
                    break;
                default:
                    break;
            }
        }
        CardsInfo.cards.panelHolder.GetComponent<PanelSwipe>().enabled = false;
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        ChestModeOpen();
    }
    void SaveChestNumber()
    {
        Items.item.chestNumber++;
        PlayerPrefs.SetInt("ChestNumber", Items.item.chestNumber);
        Items.item.chestNumber = PlayerPrefs.GetInt("ChestNumber");
    }
}
