using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterHealthManager : MonoBehaviour
{
    public static MonsterHealthManager Instance;
    public List<float> monsterHealth;
    public List<float> bossHealth;
    [SerializeField] MonsterSoldiers soldiers;
    private void Awake()
    {
        Instance = this;
    }
    void Start()
    {
        for (int i = 0; i < soldiers.spawnMonsters.Count; i++)
        {
            monsterHealth.Add(i);
            monsterHealth[i] = soldiers.spawnMonsters[i].GetComponent<MonsterStateManager>().health;
        }
        for (int i = 0; i < soldiers.bossMonster.Count; i++)
        {
            bossHealth.Add(i);
            bossHealth[i] = soldiers.bossMonster[i].GetComponent<MonsterStateManager>().health;
        }
    }
    void Update()
    {
        Application.quitting += ValueChanges;
    }
    public void HealthIncrease()
    {
        for (int i = 0; i < soldiers.spawnMonsters.Count; i++)
        {
            soldiers.spawnMonsters[i].GetComponent<MonsterStateManager>().health *= 2;
        }
        for (int i = 0; i < soldiers.bossMonster.Count; i++)
        {
            soldiers.bossMonster[i].GetComponent<MonsterStateManager>().health *= 2;
        }
    }
    void ValueChanges()
    {
        for (int i = 0; i < monsterHealth.Count; i++)
        {
            soldiers.spawnMonsters[i].GetComponent<MonsterStateManager>().health = monsterHealth[i];
        }
        for (int i = 0; i < bossHealth.Count; i++)
        {
            soldiers.bossMonster[i].GetComponent<MonsterStateManager>().health = bossHealth[i];
        }
    }
}
