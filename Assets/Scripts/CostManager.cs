using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CostManager : GenericSingleton<CostManager>
{
    public int cost;
    public int costReduce = 10;
    public int costInc = 10;
    void Update()
    {
        UIManager.Instance.costText.text = cost.ToString();
        UIManager.Instance.costReduceText.text = costReduce.ToString();
    }
    public void BuySoldier()
    {
        cost -= costReduce;
        UIManager.Instance.costText.text = cost.ToString();
        costReduce += 10;
    }
    public void KillMonster()
    {
        cost += costInc;
        UIManager.Instance.costText.text = cost.ToString();
    }
}
