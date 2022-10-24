using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class Cards : MonoBehaviour
{
    public static Cards card;
    public List<GameObject> cards;
    private void Awake()
    {
        card = this;
    }
    private void Start()
    {
        ButtonClick.instance.so = SaveManager.Load();
        for (int i = 0; i < 4; i++)
        {
            string path = cards[i].name + "/" + (cards[i].name + 1);
            GameObject variableForPrefab = Resources.Load(path) as GameObject;
            UpgradeProgress upgrade = variableForPrefab.GetComponent<UpgradeProgress>();

            TextMeshProUGUI mycard = cards[i].transform.GetChild(3).GetComponent<TextMeshProUGUI>();
            Image progress = cards[i].transform.GetChild(2).GetComponent<Image>();
            mycard.text = ButtonClick.instance.so.deckNumber[i] + " / " + ButtonClick.instance.so.levelNumber[i] * upgrade.upgradeCountCard;
            progress.fillAmount = (float)ButtonClick.instance.so.deckNumber[i] / (ButtonClick.instance.so.levelNumber[i] * upgrade.upgradeCountCard);
        }
    }
}
