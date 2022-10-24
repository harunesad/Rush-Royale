using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class ProgressUpdate : MonoBehaviour
{
    //public TextMeshProUGUI progressText;
    public TextMeshProUGUI upgradeCostText;
    public UpgradeProgress upgrade;
    void Start()
    {
        //GameObject parent = gameObject.transform.parent.gameObject;
        //string path = gameObject.name + "/" + (gameObject.name + 1);
        //GameObject variableForPrefab = Resources.Load(path) as GameObject;
        //UpgradeProgress progress = variableForPrefab.GetComponent<UpgradeProgress>();
        upgradeCostText.text = "" + upgrade.upgradeCost;
        gameObject.transform.GetChild(3).GetComponent<TextMeshProUGUI>().text = upgrade.myCountCard + "/" + upgrade.upgradeCountCard;
        gameObject.transform.GetChild(2).GetComponent<Image>().fillAmount = (float)upgrade.myCountCard / (float)upgrade.upgradeCountCard;
    }
    public void Upgrade()
    {

    }
    void Update()
    {
        //Application.quitting+=
    }
    void UpgradeUpdate()
    {

    }
}
