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
        int randomCard = Random.Range(0, commonCards.Count);
        Image card = commonCards[randomCard];
        collectCards[0].sprite = card.sprite;
        collectCards[0].name = card.name;
        Image progress = collectCards[0].transform.GetChild(0).GetComponent<Image>();
        progress.fillAmount = card.transform.GetChild(2).GetComponent<Image>().fillAmount;
        chestCardPanel.SetActive(true);
        NewProgress(card, collectCards[0], 10, 15);
    }
    public void Rare()
    {
        int randomCard = Random.Range(0, rareCards.Count);
        Image card = rareCards[randomCard];
        collectCards[1].sprite = card.sprite;
        collectCards[1].name = card.name;
        Image progress = collectCards[1].transform.GetChild(0).GetComponent<Image>();
        progress.fillAmount = card.transform.GetChild(2).GetComponent<Image>().fillAmount;
        chestCardPanel.SetActive(true);
        NewProgress(card, collectCards[1], 5, 10);
    }
    public void Epic()
    {
        int randomCard = Random.Range(0, epicCards.Count);
        Image card = epicCards[randomCard];
        collectCards[2].sprite = card.sprite;
        collectCards[2].name = card.name;
        Image progress = collectCards[2].transform.GetChild(0).GetComponent<Image>();
        progress.fillAmount = card.transform.GetChild(2).GetComponent<Image>().fillAmount;
        chestCardPanel.SetActive(true);
        NewProgress(card, collectCards[2], 1, 3);
    }
    public void UpgradeCards(int index)
    {
        for (int i = index; i < collectCards.Count; i++)
        {
            collectCards[i].gameObject.SetActive(false);
            collectCards[i].transform.GetChild(0).gameObject.SetActive(false);
        }
    }
    void NewProgress(Image card, Image cardList, int min, int max)
    {
        string path = cardList.name + "/" + (cardList.name + 1);
        GameObject variableForPrefab = Resources.Load(path) as GameObject;
        UpgradeProgress progress = variableForPrefab.GetComponent<UpgradeProgress>();
        cardList.transform.GetChild(2).GetComponent<TextMeshProUGUI>().text = Random.Range(min, max).ToString();
        progress.myCountCard += int.Parse(cardList.transform.GetChild(2).GetComponent<TextMeshProUGUI>().text);
        cardList.transform.GetChild(1).GetComponent<TextMeshProUGUI>().text = progress.myCountCard + "/" + progress.upgradeCountCard;
        cardList.transform.GetChild(0).GetComponent<Image>().fillAmount = progress.myCountCard / progress.upgradeCountCard;
        card.transform.GetChild(3).GetComponent<TextMeshProUGUI>().text = progress.myCountCard + "/" + progress.upgradeCountCard;
        card.transform.GetChild(2).GetComponent<Image>().fillAmount = progress.myCountCard / progress.upgradeCountCard;
    }
}
