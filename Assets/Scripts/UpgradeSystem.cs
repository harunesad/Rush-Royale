using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpgradeSystem : MonoBehaviour
{
    public List<int> upgradeCost;
    private void Awake()
    {
        for (int i = 0; i < upgradeCost.Count; i++)
        {
            UIManager.Instance.upgradeText[i].text = "" + upgradeCost[i];
        }
    }
    public void DivideUpgrade()
    {
        if (CostManager.Instance.cost >= upgradeCost[0])
        {
            for (int i = 0; i < SpawnSystem.Instance.soldiers.Count; i++)
            {
                if (SpawnSystem.Instance.soldiers[i].layer == 10)
                {
                    SpawnSystem.Instance.soldiers[i].GetComponent<PlayerSoldier>().attack *= 2;
                }
            }
            for (int i = 0; i < SpawnSystem.Instance.divideObj.Count; i++)
            {
                SpawnSystem.Instance.divideObj[i].GetComponent<PlayerSoldier>().attack *= 2;
            }
            CostManager.Instance.cost -= upgradeCost[0];
            upgradeCost[0] += 100;
            UIManager.Instance.upgradeText[0].text = "" + upgradeCost[0];
        }
    }
    public void MinusUpgrade()
    {
        if (CostManager.Instance.cost >= upgradeCost[1])
        {
            for (int i = 0; i < SpawnSystem.Instance.soldiers.Count; i++)
            {
                if (SpawnSystem.Instance.soldiers[i].layer == 9)
                {
                    SpawnSystem.Instance.soldiers[i].GetComponent<PlayerSoldier>().attack *= 2;
                }
            }
            for (int i = 0; i < SpawnSystem.Instance.divideObj.Count; i++)
            {
                SpawnSystem.Instance.minusObj[i].GetComponent<PlayerSoldier>().attack *= 2;
            }
            CostManager.Instance.cost -= upgradeCost[1];
            upgradeCost[1] += 100;
            UIManager.Instance.upgradeText[0].text = "" + upgradeCost[1];
        }
    }
    public void PlusUpgrade()
    {
        if (CostManager.Instance.cost >= upgradeCost[2])
        {
            for (int i = 0; i < SpawnSystem.Instance.soldiers.Count; i++)
            {
                if (SpawnSystem.Instance.soldiers[i].layer == 8)
                {
                    SpawnSystem.Instance.soldiers[i].GetComponent<PlayerSoldier>().attack *= 2;
                }
            }
            for (int i = 0; i < SpawnSystem.Instance.divideObj.Count; i++)
            {
                SpawnSystem.Instance.plusObj[i].GetComponent<PlayerSoldier>().attack *= 2;
            }
            CostManager.Instance.cost -= upgradeCost[2];
            upgradeCost[2] += 100;
            UIManager.Instance.upgradeText[0].text = "" + upgradeCost[2];
        }
    }
    public void StarUpgrade()
    {
        if (CostManager.Instance.cost >= upgradeCost[3])
        {
            for (int i = 0; i < SpawnSystem.Instance.soldiers.Count; i++)
            {
                if (SpawnSystem.Instance.soldiers[i].layer == 7)
                {
                    SpawnSystem.Instance.soldiers[i].GetComponent<PlayerSoldier>().attack *= 2;
                }
            }
            for (int i = 0; i < SpawnSystem.Instance.divideObj.Count; i++)
            {
                SpawnSystem.Instance.starObj[i].GetComponent<PlayerSoldier>().attack *= 2;
            }
            CostManager.Instance.cost -= upgradeCost[3];
            upgradeCost[3] += 100;
            UIManager.Instance.upgradeText[0].text = "" + upgradeCost[3];
        }
    }
}
