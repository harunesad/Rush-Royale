using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CostManager : GenericSingleton<CostManager>
{
    public int cost;
    public int costReduce;
    int costInc = 10;
    void Start()
    {

    }
    void Update()
    {
        UIManager.Instance.costText.text = cost.ToString();
    }
    public void BuySoldier()
    {
        costReduce += 10;
        cost -= costReduce;
        UIManager.Instance.costText.text = cost.ToString();
    }
    public void KillMonster()
    {
        cost += costInc;
        UIManager.Instance.costText.text = cost.ToString();
    }
}
