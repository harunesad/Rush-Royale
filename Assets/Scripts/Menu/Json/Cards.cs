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
        ButtonClick.instance.so = SaveManager.Load();
        for (int i = 0; i < 4; i++)
        {
            string path = cards[i].name + "/" + (cards[i].name + 1);
            GameObject variableForPrefab = Resources.Load(path) as GameObject;
            UpgradeProgress upgrade = variableForPrefab.GetComponent<UpgradeProgress>();
            BulletSpawn bulletSpawn = variableForPrefab.GetComponent<BulletSpawn>();

            bulletSpawn.attack *= Mathf.Pow(upgrade.upgradeMultiplier[0], (ButtonClick.instance.so.levelNumber[i] - 1));
            bulletSpawn.attackSpeed *= Mathf.Pow(upgrade.upgradeMultiplier[1], (ButtonClick.instance.so.levelNumber[i] - 1));
            bulletSpawn.spawnSpeed *= Mathf.Pow(upgrade.upgradeMultiplier[2], (ButtonClick.instance.so.levelNumber[i] - 1));
            GameObject upgradeObj = cards[i].transform.GetChild(4).gameObject;
            TextMeshProUGUI upgradeText = upgradeObj.transform.GetChild(0).GetComponent<TextMeshProUGUI>();
            TextMeshProUGUI mycard = cards[i].transform.GetChild(3).GetComponent<TextMeshProUGUI>();
            Image progress = cards[i].transform.GetChild(2).GetComponent<Image>();
            mycard.text = ButtonClick.instance.so.deckNumber[i] + " / " + ButtonClick.instance.so.levelNumber[i] * upgrade.upgradeCountCard;
            upgradeText.text = "" + ButtonClick.instance.so.levelCost[i] * 100;
            progress.fillAmount = (float)ButtonClick.instance.so.deckNumber[i] / (ButtonClick.instance.so.levelNumber[i] * upgrade.upgradeCountCard);

        }
    }
    //private void Start()
    //{
    //    ButtonClick.instance.so = SaveManager.Load();
    //    for (int i = 0; i < 4; i++)
    //    {
    //        string path = cards[i].name + "/" + (cards[i].name + 1);
    //        GameObject variableForPrefab = Resources.Load(path) as GameObject;
    //        UpgradeProgress upgrade = variableForPrefab.GetComponent<UpgradeProgress>();
    //        BulletSpawn bulletSpawn = variableForPrefab.GetComponent<BulletSpawn>();

    //        bulletSpawn.attack *= Mathf.Pow(upgrade.upgradeMultiplier[0], (ButtonClick.instance.so.levelNumber[i] - 1));
    //        bulletSpawn.attackSpeed *= Mathf.Pow(upgrade.upgradeMultiplier[1], (ButtonClick.instance.so.levelNumber[i] - 1));
    //        bulletSpawn.spawnSpeed *= Mathf.Pow(upgrade.upgradeMultiplier[2], (ButtonClick.instance.so.levelNumber[i] - 1));
    //        GameObject upgradeObj = cards[i].transform.GetChild(4).gameObject;
    //        TextMeshProUGUI upgradeText = upgradeObj.transform.GetChild(0).GetComponent<TextMeshProUGUI>();
    //        TextMeshProUGUI mycard = cards[i].transform.GetChild(3).GetComponent<TextMeshProUGUI>();
    //        Image progress = cards[i].transform.GetChild(2).GetComponent<Image>();
    //        mycard.text = ButtonClick.instance.so.deckNumber[i] + " / " + ButtonClick.instance.so.levelNumber[i] * upgrade.upgradeCountCard;
    //        upgradeText.text = "" + ButtonClick.instance.so.levelCost[i] * 100;
    //        progress.fillAmount = (float)ButtonClick.instance.so.deckNumber[i] / (ButtonClick.instance.so.levelNumber[i] * upgrade.upgradeCountCard);

    //    }
    //}
}
