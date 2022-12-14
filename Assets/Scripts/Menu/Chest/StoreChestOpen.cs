using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class StoreChestOpen : MonoBehaviour,IPointerDownHandler
{
    public ChestMode storeChestMode;
    public int storeChestCrystal;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public enum ChestMode
    {
        Common,
        Rare,
        Epic
    }
    public void ChestModeOpen()
    {
        if (PlayerPrefs.GetInt("Crystal") >= storeChestCrystal)
        {
            switch (storeChestMode)
            {
                case ChestMode.Common:
                    ChestCards.Instance.UpgradeStoreCards(true, false, false);
                    ChestCards.Instance.CommonStoreChest();
                    Items.item.StoreChestCoin(50, 100, "Coin");
                    Items.item.storeCrystalAddText.gameObject.SetActive(false);
                    break;
                case ChestMode.Rare:
                    ChestCards.Instance.UpgradeStoreCards(true, true, false);
                    ChestCards.Instance.CommonStoreChest();
                    ChestCards.Instance.RareStoreChest();
                    Items.item.StoreChestCoin(150, 200, "Coin");
                    Items.item.storeCrystalAddText.gameObject.SetActive(true);
                    Items.item.StoreChestCrystal(15, 25, "Crystal");
                    break;
                case ChestMode.Epic:
                    ChestCards.Instance.UpgradeStoreCards(true, true, true);
                    ChestCards.Instance.CommonStoreChest();
                    ChestCards.Instance.RareStoreChest();
                    ChestCards.Instance.EpicStoreChest();
                    Items.item.StoreChestCoin(250, 400, "Coin");
                    Items.item.storeCrystalAddText.gameObject.SetActive(true);
                    Items.item.StoreChestCrystal(35, 50, "Crystal");
                    break;
                default:
                    break;
            }
        }
    }
    public void OnPointerDown(PointerEventData eventData)
    {
        ChestModeOpen();
        Debug.Log("saddsa");
    }
}
