using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UpgradeSystem : GenericSingleton<UpgradeSystem>
{
    [SerializeField] PlayerSoldiers soldiers;
    public List<int> upgradeCost;
    public List<TextMeshProUGUI> upgradeCostText;
    public List<TextMeshProUGUI> upgradeText;
    public List<float> divide;
    public List<float> minus;
    public List<float> plus;
    public List<float> star;
    public override void Awake()
    {
        base.Awake();
        PropertyUpdate(soldiers.firstObj);
        PropertyUpdate(soldiers.secondObj);
        PropertyUpdate(soldiers.thirdObj);
        PropertyUpdate(soldiers.fourthObj);
        for (int i = 0; i < upgradeCost.Count; i++)
        {
            upgradeCostText[i].text = "" + upgradeCost[i];
        }
    }
    private void Start()
    {
        StartValue(soldiers.firstObj, divide);
        StartValue(soldiers.secondObj, minus);
        StartValue(soldiers.thirdObj, plus);
        StartValue(soldiers.fourthObj, star);
        SpecialAttack.removeUpgrade += RemoveUpgrade;
    }
    void PropertyUpdate(List<GameObject> obj)
    {
        for (int i = 0; i < obj.Count - 1; i++)
        {
            obj[i + 1].GetComponent<BulletSpawn>().spawnSpeed = obj[i].GetComponent<BulletSpawn>().spawnSpeed * obj[0].GetComponent<UpgradeProgress>().levelMultiplier[3];
            obj[i + 1].GetComponent<BulletSpawn>().attack = obj[i].GetComponent<BulletSpawn>().attack * obj[0].GetComponent<UpgradeProgress>().levelMultiplier[2];
            obj[i + 1].GetComponent<BulletSpawn>().attackSpeed = obj[i].GetComponent<BulletSpawn>().attackSpeed * obj[0].GetComponent<UpgradeProgress>().levelMultiplier[1];
        }
    }
    void RemoveUpgrade(int index)
    {
        upgradeCost[index] -= 100;
        upgradeCostText[index].text = "" + upgradeCost[index];
    }
    private void Update()
    {
        Application.quitting += LastValue;
    }
    public void FirstUpgrade()
    {
        Upgrade(soldiers.firstObj, 0, soldiers.firstObj[0].layer);
    }
    public void SecondUpgrade()
    {
        Upgrade(soldiers.secondObj, 1, soldiers.secondObj[0].layer);
    }
    public void ThirdUpgrade()
    {
        Upgrade(soldiers.thirdObj, 2, soldiers.thirdObj[0].layer);
    }
    public void FourthUpgrade()
    {
        Upgrade(soldiers.fourthObj, 3, soldiers.fourthObj[0].layer);
    }
    void LastValue()
    {
        Value(soldiers.firstObj, divide);
        Value(soldiers.secondObj, minus);
        Value(soldiers.thirdObj, plus);
        Value(soldiers.fourthObj, star);
    }
    void Value(List<GameObject> obj, List<float> objValue)
    {
        for (int i = 0; i < objValue.Count; i++)
        {
            obj[i].GetComponent<BulletSpawn>().attack = objValue[i];
        }
    }
    void StartValue(List<GameObject> obj, List<float> objValue)
    {
        for (int i = 0; i < obj.Count; i++)
        {
            objValue.Add(i);
            objValue[i] = obj[i].GetComponent<BulletSpawn>().attack;
        }
    }
    void Upgrade(List<GameObject> objects, int index, int layer)
    {
        if (CostManager.Instance.cost >= upgradeCost[index] && Time.timeScale == 1)
        {
            for (int i = 0; i < SpawnSystem.Instance.soldiers.Count; i++)
            {
                if (SpawnSystem.Instance.soldiers[i].layer == layer)
                {
                    UpgradeProgress progress = SpawnSystem.Instance.soldiers[0].GetComponent<UpgradeProgress>();
                    SpawnSystem.Instance.soldiers[i].GetComponent<BulletSpawn>().attack *= progress.levelMultiplier[0];
                }
            }
            for (int i = 0; i < objects.Count; i++)
            {
                objects[i].GetComponent<BulletSpawn>().attack *= 2;
            }

            CostManager.Instance.cost -= upgradeCost[index];
            upgradeCost[index] += 100;
            upgradeCostText[index].text = "" + upgradeCost[index];
        }
    }
}
