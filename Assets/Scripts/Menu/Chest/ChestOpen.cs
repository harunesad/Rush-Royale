using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChestOpen : MonoBehaviour
{
    public ChestMode chestMode;
    public int chestProgress;
    public enum ChestMode
    {
        Common,
        Rare,
        Epic
    }
    void Start()
    {
        if (PlayerPrefs.GetInt("Coin") >= chestProgress)
        {
            gameObject.transform.GetChild(0).gameObject.SetActive(false);
            gameObject.AddComponent<Button>();
            gameObject.GetComponent<Button>().onClick.AddListener(ChestClick);
        }
    }
    void Update()
    {

    }
    void ChestClick()
    {
        ChestModeOpen();
        ButtonClick.instance.panelHolder.GetComponent<PanelSwipe>().enabled = false;
    }
    public void ChestModeOpen()
    {
        switch (chestMode)
        {
            case ChestMode.Common:
                ChestCards.Instance.UpgradeCards(1);
                ChestCards.Instance.Common();
                break;
            case ChestMode.Rare:
                ChestCards.Instance.UpgradeCards(2);
                ChestCards.Instance.Common();
                ChestCards.Instance.Rare();
                break;
            case ChestMode.Epic:
                ChestCards.Instance.Common();
                ChestCards.Instance.Rare();
                ChestCards.Instance.Epic();
                break;
            default:
                break;
        }
    }
}
