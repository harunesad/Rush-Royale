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
    public GameObject chestCardPanel;
    int cardCount;
    private void Awake()
    {
        Instance = this;
    }
    void Start()
    {

    }
    void Update()
    {

    }
    public void Common()
    {
        //int randomCard = Random.Range(0, commonCards.Count);
        //Image card = commonCards[randomCard];
        //collectCards[0].sprite = card.sprite;
        //collectCards[0].name = card.name;
        //Image progress = collectCards[0].transform.GetChild(0).GetComponent<Image>();
        //progress.fillAmount = card.transform.GetChild(2).GetComponent<Image>().fillAmount;
        //chestCardPanel.SetActive(true);
        //NewProgress(card, collectCards[0], 10, 15);
        CardType(commonCards, collectCards[0], 10, 15);
    }
    public void Rare()
    {
        //int randomCard = Random.Range(0, rareCards.Count);
        //Image card = rareCards[randomCard];
        //collectCards[1].sprite = card.sprite;
        //collectCards[1].name = card.name;
        //Image progress = collectCards[1].transform.GetChild(0).GetComponent<Image>();
        //progress.fillAmount = card.transform.GetChild(2).GetComponent<Image>().fillAmount;
        //chestCardPanel.SetActive(true);
        //NewProgress(card, collectCards[1], 5, 10);
        CardType(rareCards, collectCards[1], 5, 10);
    }
    public void Epic()
    {
        //int randomCard = Random.Range(0, epicCards.Count);
        //Image card = epicCards[randomCard];
        //collectCards[2].sprite = card.sprite;
        //collectCards[2].name = card.name;
        //Image progress = collectCards[2].transform.GetChild(0).GetComponent<Image>();
        //progress.fillAmount = card.transform.GetChild(2).GetComponent<Image>().fillAmount;
        //chestCardPanel.SetActive(true);
        //NewProgress(card, collectCards[2], 1, 3);
        CardType(epicCards, collectCards[2], 1, 3);
    }
    public void UpgradeCards(bool common, bool rare, bool epic)
    {
        TrueOrFalse(0, common);
        TrueOrFalse(1, rare);
        TrueOrFalse(2, epic);
    }
    void TrueOrFalse(int index, bool cardState)
    {
        collectCards[index].gameObject.SetActive(cardState);
        collectCards[index].transform.GetChild(0).gameObject.SetActive(cardState);
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
        //progress.myCountCard += int.Parse(cardIncText.text);
        for (int i = 0; i < Cards.card.cards.Count; i++)
        {
            if (card.name == Cards.card.cards[i].name)
            {
                cardCount = i;
            }
        }
        ButtonClick.instance.so.deckNumber[cardCount] += int.Parse(cardIncText.text);
        int cardCounts = ButtonClick.instance.so.deckNumber[cardCount];
        int levelNumber = ButtonClick.instance.so.levelNumber[cardCount];
        //cardList.transform.GetChild(1).GetComponent<TextMeshProUGUI>().text = progress.myCountCard + "/" + progress.upgradeCountCard;
        cardList.transform.GetChild(1).GetComponent<TextMeshProUGUI>().text = cardCounts + "/" + progress.upgradeCountCard * levelNumber;
        //cardList.transform.GetChild(0).GetComponent<Image>().fillAmount = (float)progress.myCountCard / (float)progress.upgradeCountCard;
        cardList.transform.GetChild(0).GetComponent<Image>().fillAmount = (float)cardCounts / (float)progress.upgradeCountCard * levelNumber;
        //card.transform.GetChild(3).GetComponent<TextMeshProUGUI>().text = progress.myCountCard + "/" + progress.upgradeCountCard;
        card.transform.GetChild(3).GetComponent<TextMeshProUGUI>().text = cardCounts + "/" + progress.upgradeCountCard * levelNumber;
        //card.transform.GetChild(2).GetComponent<Image>().fillAmount = (float)progress.myCountCard / (float)progress.upgradeCountCard;
        card.transform.GetChild(2).GetComponent<Image>().fillAmount = (float)cardCounts / (float)progress.upgradeCountCard * levelNumber;
        Debug.Log(progress.myCountCard / progress.upgradeCountCard);
        SaveManager.Save(ButtonClick.instance.so);
    }
}
