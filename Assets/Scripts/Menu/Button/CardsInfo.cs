using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CardsInfo : MonoBehaviour
{
    public static CardsInfo cards;
    public GameObject panelHolder;
    [SerializeField] GameObject ýnfoPanel;
    GameObject parentObj;
    public UpgradeProgress progress;
    public BulletSpawn bulletSpawn;
    float levelNumber = 1, mergeRateNumber = 1, attack, attackSpeed, spawnSpeed;
    int cardIndex;
    public TextMeshProUGUI attackText;
    public TextMeshProUGUI attackSpeedText;
    public TextMeshProUGUI spawnSpeedText;
    [SerializeField] TextMeshProUGUI soldierNameText;
    [SerializeField] TextMeshProUGUI levelText;
    [SerializeField] TextMeshProUGUI mergeText;
    [SerializeField] TextMeshProUGUI upgradeCostText;
    [SerializeField] Image sprite;
    private void Awake()
    {
        cards = this;
    }
    public void InfoButton(Button clickButton)
    {
        panelHolder.GetComponent<PanelSwipe>().enabled = false;
        ýnfoPanel.SetActive(true);

        var obj = clickButton.transform.parent;
        parentObj = obj.gameObject;

        string soldierName = parentObj.name + 1;
        string path = parentObj.name + "/" + soldierName;
        Debug.Log(path);

        GameObject variableForPrefab = Resources.Load(path) as GameObject;
        bulletSpawn = variableForPrefab.GetComponent<BulletSpawn>();
        progress = variableForPrefab.GetComponent<UpgradeProgress>();

        if (ButtonSelect.instance.upgradeButton.activeSelf)
        {
            GameObject parent = upgradeCostText.transform.parent.gameObject;
            //parent.gameObject.SetActive(true);
            parent.GetComponent<Button>().interactable = true;
            Debug.Log(parent.name);
            UpgradeCards.instance.IncreaseShow(parentObj);
        }
        ButtonState();

        Property();

        sprite.GetComponent<Image>().sprite = parentObj.GetComponent<Image>().sprite;
        soldierNameText.text = parentObj.name;
        upgradeCostText.text = "" + progress.upgradeCost;
        for (int i = 0; i < 4; i++)
        {
            if (Cards.card.cards[i].name == parentObj.name)
            {
                cardIndex = i;
            }
        }
        GameObject upgrade = parentObj.transform.GetChild(4).gameObject;
        TextMeshProUGUI upgradeText = upgrade.transform.GetChild(0).GetComponent<TextMeshProUGUI>();
        upgradeText.text = "" + ButtonClick.instance.so.levelCost[cardIndex] * 100;
    }
    public void LevelClick()
    {
        if (levelNumber != 4)
        {
            levelNumber++;
            attack *= progress.levelMultiplier[0];
            attackText.text = "" + attack;
        }
        else
        {
            levelNumber = 1;
            attack = attack / Mathf.Pow(progress.levelMultiplier[0], 3);
            attackText.text = "" + attack;
        }
        levelText.text = "Level " + levelNumber;
    }
    public void MergeRate()
    {
        if (mergeRateNumber != 4)
        {
            mergeRateNumber++;
            attack *= progress.levelMultiplier[2];
            attackSpeed *= progress.levelMultiplier[1];
            spawnSpeed *= progress.levelMultiplier[3];
            attackText.text = "" + attack;
            attackSpeedText.text = "" + attackSpeed.ToString("F1");
            spawnSpeedText.text = "" + spawnSpeed.ToString("F1");
        }
        else
        {
            mergeRateNumber = 1;
            attack = attack / Mathf.Pow(progress.levelMultiplier[2], 3);
            attackSpeed = attackSpeed / Mathf.Pow(progress.levelMultiplier[1], 3);
            spawnSpeed = spawnSpeed / Mathf.Pow(progress.levelMultiplier[3], 3);
            attackText.text = "" + attack;
            attackSpeedText.text = "" + attackSpeed.ToString("F1");
            spawnSpeedText.text = "" + spawnSpeed.ToString("F1");
        }
        mergeText.text = "Merge Rate " + mergeRateNumber;
    }
    public void PanelClose()
    {
        panelHolder.GetComponent<PanelSwipe>().enabled = true;
        ýnfoPanel.SetActive(false);
        ButtonState();

        levelNumber = 1;
        mergeRateNumber = 1;
        Property();
        levelText.text = "Level " + levelNumber;
        mergeText.text = "Merge Rate " + mergeRateNumber;

        GameObject parent = upgradeCostText.transform.parent.gameObject;
        //parent.gameObject.SetActive(true);
        parent.GetComponent<Button>().interactable = false;
    }
    void ButtonState()
    {
        parentObj.transform.GetChild(0).gameObject.SetActive(false);
        parentObj.transform.GetChild(1).gameObject.SetActive(false);
        parentObj.transform.GetChild(2).gameObject.SetActive(true);
        parentObj.transform.GetChild(3).gameObject.SetActive(true);
        parentObj.transform.GetChild(4).gameObject.SetActive(false);
    }
    void Property()
    {
        attack = bulletSpawn.attack;
        attackSpeed = bulletSpawn.attackSpeed;
        spawnSpeed = bulletSpawn.spawnSpeed;
        attackText.text = "" + attack;
        attackSpeedText.text = "" + attackSpeed;
        spawnSpeedText.text = "" + spawnSpeed;
    }
}
