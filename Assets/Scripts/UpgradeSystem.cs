using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpgradeSystem : GenericSingleton<UpgradeSystem>
{
    public List<int> upgradeCost;
    public List<float> divide;
    public List<float> minus;
    public List<float> plus;
    public List<float> star;
    private void Awake()
    {
        for (int i = 0; i < upgradeCost.Count; i++)
        {
            UIManager.Instance.upgradeText[i].text = "" + upgradeCost[i];
        }
    }
    private void Start()
    {
        StartValue(SpawnSystem.Instance.divideObj, divide);
        StartValue(SpawnSystem.Instance.minusObj, minus);
        StartValue(SpawnSystem.Instance.plusObj, plus);
        StartValue(SpawnSystem.Instance.starObj, star);
    }
    private void Update()
    {
        Application.quitting += LastValue;
    }
    public void DivideUpgrade()
    {
        Upgrade(SpawnSystem.Instance.divideObj, 0, 10);
    }
    public void MinusUpgrade()
    {
        Upgrade(SpawnSystem.Instance.minusObj, 1, 9);
    }
    public void PlusUpgrade()
    {
        Upgrade(SpawnSystem.Instance.plusObj, 2, 8);
    }
    public void StarUpgrade()
    {
        Upgrade(SpawnSystem.Instance.starObj, 3, 7);
    }
    void LastValue()
    {
        Value(SpawnSystem.Instance.divideObj, divide);
        Value(SpawnSystem.Instance.minusObj, minus);
        Value(SpawnSystem.Instance.plusObj, plus);
        Value(SpawnSystem.Instance.starObj, star);
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
        if (CostManager.Instance.cost >= upgradeCost[index])
        {
            for (int i = 0; i < SpawnSystem.Instance.soldiers.Count; i++)
            {
                if (SpawnSystem.Instance.soldiers[i].layer == layer)
                {
                    SpawnSystem.Instance.soldiers[i].GetComponent<BulletSpawn>().attack *= 2;
                }
            }
            for (int i = 0; i < objects.Count; i++)
            {
                objects[i].GetComponent<BulletSpawn>().attack *= 2;
            }

            CostManager.Instance.cost -= upgradeCost[index];
            upgradeCost[index] += 100;
            UIManager.Instance.upgradeText[index].text = "" + upgradeCost[index];
        }
    }
}
