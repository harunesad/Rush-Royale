using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CostManager : GenericSingleton<CostManager>
{
    public int cost;
    public int costReduce = 10;

    public List<int> monsterCostInc;
    public List<int> bossCostInc;
    private void Start()
    {
        for (int i = 0; i < SpawnMonsters.Instance.spawnMonsters.Count; i++)
        {
            monsterCostInc.Add(i);
            monsterCostInc[i] = SpawnMonsters.Instance.spawnMonsters[i].GetComponent<MonsterStateManager>().costIncrease;
        }
        for (int i = 0; i < SpawnMonsters.Instance.bossMonster.Count; i++)
        {
            bossCostInc.Add(i);
            bossCostInc[i] = SpawnMonsters.Instance.bossMonster[i].GetComponent<MonsterStateManager>().costIncrease;
        }
    }
    void Update()
    {
        UIManager.Instance.costText.text = cost.ToString();
        UIManager.Instance.costReduceText.text = costReduce.ToString();
        Application.quitting += ValueChanges;
    }
    public void BuySoldier()
    {
        cost -= costReduce;
        UIManager.Instance.costText.text = cost.ToString();
        costReduce += 10;
    }
    public void KillMonster(int costInc)
    {
        cost += costInc;
        UIManager.Instance.costText.text = cost.ToString();
    }
    public void CostInc()
    {
        for (int i = 0; i < SpawnMonsters.Instance.spawnMonsters.Count; i++)
        {
            SpawnMonsters.Instance.spawnMonsters[i].GetComponent<MonsterStateManager>().costIncrease *= 2;
        }
        for (int i = 0; i < SpawnMonsters.Instance.bossMonster.Count; i++)
        {
            SpawnMonsters.Instance.bossMonster[i].GetComponent<MonsterStateManager>().costIncrease *= 2;
        }
    }
    void ValueChanges()
    {
        for (int i = 0; i < monsterCostInc.Count; i++)
        {
            SpawnMonsters.Instance.spawnMonsters[i].GetComponent<MonsterStateManager>().costIncrease = monsterCostInc[i];
        }
        for (int i = 0; i < bossCostInc.Count; i++)
        {
            SpawnMonsters.Instance.bossMonster[i].GetComponent<MonsterStateManager>().costIncrease = bossCostInc[i];
        }
    }
}
