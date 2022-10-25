using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class ChestCards : MonoBehaviour
{
    public static ChestCards Instance;
    public List<Image> commonCards;
    public List<Image> rareCards;
    public List<Image> epicCards;
    public List<Image> collectCards;
    public List<Image> collectStoreCards;
    public GameObject chestCardPanel;
    int cardCount;
    private void Awake()
    {
        Instance = this;
    }
    public void CommonStoreChest()
    {
        CardType(commonCards, collectStoreCards[0], 10, 15);

    }
    public void RareStoreChest()
    {
        CardType(rareCards, collectStoreCards[1], 10, 15);
    }
    public void EpicStoreChest()
    {
        CardType(epicCards, collectStoreCards[2], 10, 15);
    }
    public void CommonChest()
    {
        CardType(commonCards, collectCards[0], 10, 15);
    }
    public void RareChest()
    {
        CardType(rareCards, collectCards[1], 5, 10);
    }
    public void EpicChest()
    {
        CardType(epicCards, collectCards[2], 1, 3);
    }
    public void UpgradeCards(bool common, bool rare, bool epic)
    {
        TrueOrFalse(collectCards[0], common);
        TrueOrFalse(collectCards[1], rare);
        TrueOrFalse(collectCards[2], epic);
    }
    public void UpgradeStoreCards(bool common, bool rare, bool epic)
    {
        TrueOrFalse(collectStoreCards[0], common);
        TrueOrFalse(collectStoreCards[1], rare);
        TrueOrFalse(collectStoreCards[2], epic);
    }
    void TrueOrFalse(Image collectStore, bool cardState)
    {
        collectStore.gameObject.SetActive(cardState);
        collectStore.transform.GetChild(0).gameObject.SetActive(cardState);
    }
    void CardType(List<Image> type, Image collect, int min, int max)
    {
        ButtonClick.instance.so = SaveManager.Load();
        int randomCard = Random.Range(0, type.Count);
        Image card = type[randomCard];
        collect.sprite = card.sprite;
        collect.name = card.name;
        Image progress = collect.transform.GetChild(0).GetComponent<Image>();
        progress.fillAmount = card.transform.GetChild(2).GetComponent<Image>().fillAmount;
        chestCardPanel.SetActive(true);
        NewProgress(card, collect, min, max);
    }
    void NewProgress(Image card, Image cardList, int min, int max)
    {
        string path = cardList.name + "/" + (cardList.name + 1);
        GameObject variableForPrefab = Resources.Load(path) as GameObject;
        UpgradeProgress progress = variableForPrefab.GetComponent<UpgradeProgress>();
        TextMeshProUGUI cardIncText = cardList.transform.GetChild(2).GetComponent<TextMeshProUGUI>();
        cardIncText.text = Random.Range(min, max).ToString();
        for (int i = 0; i < 4; i++)
        {
            if (card.name == Cards.card.cards[i].name)
            {
                cardCount = i;
            }
        }
        ButtonClick.instance.so.deckNumber[cardCount] += int.Parse(cardIncText.text);
        int cardCounts = ButtonClick.instance.so.deckNumber[cardCount];
        int levelNumber = ButtonClick.instance.so.levelNumber[cardCount];
        cardList.transform.GetChild(1).GetComponent<TextMeshProUGUI>().text = cardCounts + "/" + progress.upgradeCountCard * levelNumber;
        cardList.transform.GetChild(0).GetComponent<Image>().fillAmount = (float)cardCounts / (float)progress.upgradeCountCard * levelNumber;
        card.transform.GetChild(3).GetComponent<TextMeshProUGUI>().text = cardCounts + "/" + progress.upgradeCountCard * levelNumber;
        card.transform.GetChild(2).GetComponent<Image>().fillAmount = (float)cardCounts / (float)progress.upgradeCountCard * levelNumber;
        Debug.Log(progress.myCountCard / progress.upgradeCountCard);
        SaveManager.Save(ButtonClick.instance.so);
    }
}
