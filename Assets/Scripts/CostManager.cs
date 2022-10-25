using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CostManager : MonoBehaviour
{
    public static CostManager Instance;
    public int cost;
    public int costReduce = 10;

    public List<int> monsterCostInc;
    public List<int> bossCostInc;

    [SerializeField] MonsterSoldiers soldiers;

    public TextMeshProUGUI costText;
    public TextMeshProUGUI costReduceText;
    private void Awake()
    {
        Instance = this;
    }
    private void Start()
    {
        for (int i = 0; i < soldiers.spawnMonsters.Count; i++)
        {
            monsterCostInc.Add(i);
            monsterCostInc[i] = soldiers.spawnMonsters[i].GetComponent<MonsterStateManager>().costIncrease;
        }
        for (int i = 0; i < soldiers.bossMonster.Count; i++)
        {
            bossCostInc.Add(i);
            bossCostInc[i] = soldiers.bossMonster[i].GetComponent<MonsterStateManager>().costIncrease;
        }
        DieMonster.bossDie += CostInc;
    }
    void Update()
    {
        costText.text = cost.ToString();
        costReduceText.text = costReduce.ToString();
        Application.quitting += ValueChanges;
    }
    public void BuySoldier()
    {
        cost -= costReduce;
        costText.text = cost.ToString();
        costReduce += 10;
    }
    public void KillMonster(int costInc)
    {
        cost += costInc;
        costText.text = cost.ToString();
    }
    public void CostInc()
    {
        for (int i = 0; i < soldiers.spawnMonsters.Count; i++)
        {
            soldiers.spawnMonsters[i].GetComponent<MonsterStateManager>().costIncrease *= 2;
        }
        for (int i = 0; i < soldiers.bossMonster.Count; i++)
        {
            soldiers.bossMonster[i].GetComponent<MonsterStateManager>().costIncrease *= 2;
        }
        Debug.Log("sadassad");
    }
    void ValueChanges()
    {
        for (int i = 0; i < monsterCostInc.Count; i++)
        {
            soldiers.spawnMonsters[i].GetComponent<MonsterStateManager>().costIncrease = monsterCostInc[i];
        }
        for (int i = 0; i < bossCostInc.Count; i++)
        {
            soldiers.bossMonster[i].GetComponent<MonsterStateManager>().costIncrease = bossCostInc[i];
        }
    }
}
