using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterHealthManager : GenericSingleton<MonsterHealthManager>
{
    public List<float> monsterHealth;
    public List<float> bossHealth;
    void Start()
    {
        for (int i = 0; i < SpawnMonsters.Instance.spawnMonsters.Count; i++)
        {
            monsterHealth.Add(i);
            monsterHealth[i] = SpawnMonsters.Instance.spawnMonsters[i].GetComponent<MonsterStateManager>().health;
        }
        for (int i = 0; i < SpawnMonsters.Instance.bossMonster.Count; i++)
        {
            bossHealth.Add(i);
            bossHealth[i] = SpawnMonsters.Instance.bossMonster[i].GetComponent<MonsterStateManager>().health;
        }
    }
    void Update()
    {
        Application.quitting += ValueChanges;
    }
    public void HealthIncrease()
    {
        for (int i = 0; i < SpawnMonsters.Instance.spawnMonsters.Count; i++)
        {
            SpawnMonsters.Instance.spawnMonsters[i].GetComponent<MonsterStateManager>().health *= 2;
        }
        for (int i = 0; i < SpawnMonsters.Instance.bossMonster.Count; i++)
        {
            SpawnMonsters.Instance.bossMonster[i].GetComponent<MonsterStateManager>().health *= 2;
        }
    }
    void ValueChanges()
    {
        for (int i = 0; i < monsterHealth.Count; i++)
        {
            SpawnMonsters.Instance.spawnMonsters[i].GetComponent<MonsterStateManager>().health = monsterHealth[i];
        }
        for (int i = 0; i < bossHealth.Count; i++)
        {
            SpawnMonsters.Instance.bossMonster[i].GetComponent<MonsterStateManager>().health = bossHealth[i];
        }
    }
}
