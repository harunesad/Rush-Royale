using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CostManager : GenericSingleton<CostManager>
{
    public TextMeshProUGUI costText;
    public int cost;
    public int costReduce;
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
}
