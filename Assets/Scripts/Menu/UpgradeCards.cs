using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UpgradeCards : MonoBehaviour
{
    public TextMeshProUGUI attackIncText;
    public TextMeshProUGUI attackSpeedIncText;
    public TextMeshProUGUI spawnSpeedIncText;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void UpgradeCard()
    {
        CardsInfo.cards.bulletSpawn.attack *= CardsInfo.cards.progress.upgradeMultiplier[0];
        CardsInfo.cards.bulletSpawn.attackSpeed *= CardsInfo.cards.progress.upgradeMultiplier[1];
        CardsInfo.cards.bulletSpawn.spawnSpeed *= CardsInfo.cards.progress.upgradeMultiplier[2];
        CardsInfo.cards.progress.upgradeCost *= 2;
        CardsInfo.cards.attackText.text = "" + CardsInfo.cards.bulletSpawn.attack;
        CardsInfo.cards.attackSpeedText.text = "" + CardsInfo.cards.bulletSpawn.attackSpeed;
        CardsInfo.cards.spawnSpeedText.text = "" + CardsInfo.cards.bulletSpawn.spawnSpeed;
        attackIncText.text = "" + (CardsInfo.cards.progress.upgradeMultiplier[0] - 1) * CardsInfo.cards.bulletSpawn.attack;
        attackSpeedIncText.text = "" + (CardsInfo.cards.progress.upgradeMultiplier[1] - 1) * CardsInfo.cards.bulletSpawn.attackSpeed;
        spawnSpeedIncText.text = "" + (CardsInfo.cards.progress.upgradeMultiplier[2] - 1) * CardsInfo.cards.bulletSpawn.spawnSpeed;
    }
}
