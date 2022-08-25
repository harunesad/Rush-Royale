using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CostManager : GenericSingleton<CostManager>
{
    public TextMeshProUGUI costText;
    public int cost;
    public int costReduce;
    int costInc = 10;
    void Start()
    {

    }
    void Update()
    {
        costText.text = cost.ToString();
    }
    public void BuySoldier()
    {
        costReduce += 10;
        cost -= costReduce;
        costText.text = cost.ToString();
    }
    public void KillMonster()
    {
        cost += costInc;
        costText.text = cost.ToString();
    }
}
