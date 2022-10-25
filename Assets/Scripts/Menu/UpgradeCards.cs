using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UpgradeCards : MonoBehaviour
{
    public static UpgradeCards instance;
    public TextMeshProUGUI attackIncText;
    public TextMeshProUGUI attackSpeedIncText;
    public TextMeshProUGUI spawnSpeedIncText;
    public TextMeshProUGUI cardLevel;
    public TextMeshProUGUI cardCost;
    public Button upgradeButton;
    int cardIndex;
    float attack, attackSpeed, spawnSpeed, lastAttack, lastAttackSpeed, lastSpawnSpeed;
    private void Awake()
    {
        instance = this;
    }
    void Start()
    {
        ButtonClick.instance.so = SaveManager.Load();
    }

    // Update is called once per frame
    void Update()
    {

    }
    public void UpgradeCard(GameObject soldier)
    {
        //for (int i = 0; i < 4; i++)
        //{
        //    if (Cards.card.cards[i].GetComponent<Image>().sprite.name == soldier.GetComponent<Image>().sprite.name)
        //    {
        //        cardIndex = i;
        //    }
        //}
        IncreaseReset();
        //attack = Mathf.Pow(CardsInfo.cards.progress.upgradeMultiplier[0], ButtonClick.instance.so.levelNumber[cardIndex]);
        //lastAttack = Mathf.Pow(CardsInfo.cards.progress.upgradeMultiplier[0], (ButtonClick.instance.so.levelNumber[cardIndex] - 1));
        CardsInfo.cards.bulletSpawn.attack *= attack;

        //attackSpeed = Mathf.Pow(CardsInfo.cards.progress.upgradeMultiplier[1], ButtonClick.instance.so.levelNumber[cardIndex]);
        //lastAttackSpeed = Mathf.Pow(CardsInfo.cards.progress.upgradeMultiplier[1], (ButtonClick.instance.so.levelNumber[cardIndex] - 1));
        CardsInfo.cards.bulletSpawn.attackSpeed *= attackSpeed;

        //spawnSpeed = Mathf.Pow(CardsInfo.cards.progress.upgradeMultiplier[2], ButtonClick.instance.so.levelNumber[cardIndex]);
        //lastSpawnSpeed = Mathf.Pow(CardsInfo.cards.progress.upgradeMultiplier[2], (ButtonClick.instance.so.levelNumber[cardIndex] - 1));
        CardsInfo.cards.bulletSpawn.spawnSpeed *= spawnSpeed;

        ButtonClick.instance.so.deckNumber[cardIndex] -= (CardsInfo.cards.progress.upgradeCountCard * ButtonClick.instance.so.levelNumber[cardIndex]);
        ButtonClick.instance.so.levelCost[cardIndex] = ButtonClick.instance.so.levelCost[cardIndex] * 2;
        ButtonClick.instance.so.levelNumber[cardIndex]++;

        CardsInfo.cards.progress.upgradeCost *= ButtonClick.instance.so.levelCost[cardIndex];
        CardsInfo.cards.attackText.text = "" + CardsInfo.cards.bulletSpawn.attack;
        CardsInfo.cards.attackSpeedText.text = "" + CardsInfo.cards.bulletSpawn.attackSpeed;
        CardsInfo.cards.spawnSpeedText.text = "" + CardsInfo.cards.bulletSpawn.spawnSpeed;

        //attackIncText.text = "" + Mathf.Abs(attack - lastAttack);
        //attackSpeedIncText.text = "" + Mathf.Abs(attackSpeed - lastAttackSpeed);
        //spawnSpeedIncText.text = "" + Mathf.Abs(spawnSpeed - lastSpawnSpeed);

        cardLevel.text = "" + ButtonClick.instance.so.levelNumber[cardIndex];
        cardCost.text = "" + ButtonClick.instance.so.levelCost[cardIndex] * 100;

        upgradeButton.GetComponent<Button>().interactable = false;
        Image progress = Cards.card.cards[cardIndex].transform.GetChild(2).GetComponent<Image>();
        TextMeshProUGUI myCard = Cards.card.cards[cardIndex].transform.GetChild(3).GetComponent<TextMeshProUGUI>();
        myCard.text = ButtonClick.instance.so.deckNumber[cardIndex] + " / " + CardsInfo.cards.progress.upgradeCountCard * ButtonClick.instance.so.levelNumber[cardIndex];
        progress.fillAmount = (float)ButtonClick.instance.so.deckNumber[cardIndex] / (CardsInfo.cards.progress.upgradeCountCard * ButtonClick.instance.so.levelNumber[cardIndex]);
        SaveManager.Save(ButtonClick.instance.so);
    }
    public void IncreaseShow(GameObject soldier)
    {
        for (int i = 0; i < 4; i++)
        {
            if (Cards.card.cards[i].name == soldier.name)
            {
                cardIndex = i;
                Debug.Log(cardIndex);
            }
        }

        attack = Mathf.Pow(CardsInfo.cards.progress.upgradeMultiplier[0], ButtonClick.instance.so.levelNumber[cardIndex]);
        lastAttack = Mathf.Pow(CardsInfo.cards.progress.upgradeMultiplier[0], (ButtonClick.instance.so.levelNumber[cardIndex] - 1));
        attackSpeed = Mathf.Pow(CardsInfo.cards.progress.upgradeMultiplier[1], ButtonClick.instance.so.levelNumber[cardIndex]);
        lastAttackSpeed = Mathf.Pow(CardsInfo.cards.progress.upgradeMultiplier[1], (ButtonClick.instance.so.levelNumber[cardIndex] - 1));
        spawnSpeed = Mathf.Pow(CardsInfo.cards.progress.upgradeMultiplier[2], ButtonClick.instance.so.levelNumber[cardIndex]);
        lastSpawnSpeed = Mathf.Pow(CardsInfo.cards.progress.upgradeMultiplier[2], (ButtonClick.instance.so.levelNumber[cardIndex] - 1));
        attackIncText.text = "" + Mathf.Abs(attack - lastAttack);
        attackSpeedIncText.text = "" + Mathf.Abs(attackSpeed - lastAttackSpeed);
        spawnSpeedIncText.text = "" + Mathf.Abs(spawnSpeed - lastSpawnSpeed);
    }
    void IncreaseReset()
    {
        attackIncText.text = "";
        attackSpeedIncText.text = "";
        spawnSpeedIncText.text = "";
    }
}
