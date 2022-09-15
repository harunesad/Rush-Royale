using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnMonsters : GenericSingleton<SpawnMonsters>
{
    [SerializeField] List<GameObject> spawnMonsters;
    [SerializeField] Transform spawnPoint;
    [SerializeField] List<GameObject> bossMonster;

    public List<float> monsterHealth;
    public List<float> bossHealth;
    private void Start()
    {
        for (int i = 0; i < spawnMonsters.Count; i++)
        {
            monsterHealth.Add(i);
            monsterHealth[i] = spawnMonsters[i].GetComponent<MonsterStateManager>().health;
        }
        for (int i = 0; i < bossMonster.Count; i++)
        {
            bossHealth.Add(i);
            bossHealth[i] = bossMonster[i].GetComponent<MonsterStateManager>().health;
        }
        InvokeRepeating("SpawnSlow", 2, 1);
        InvokeRepeating("SpawnFast", 4, 5);
        InvokeRepeating("SpawnBig", 11, 10);
    }
    private void Update()
    {
        Application.quitting += ValueChanges;
    }
    public void ReSpawn(string methodName, int time, int repeatTime)
    {
        if (!IsInvoking(methodName))
        {
            InvokeRepeating(methodName, time, repeatTime);
        }
    }
    public void ReSpawnObj()
    {
        ReSpawn("SpawnSlow", 2, 1);
        ReSpawn("SpawnFast", 4, 5);
        ReSpawn("SpawnBig", 11, 10);
    }
    void SpawnSlow()
    {
        Spawn(spawnMonsters, 0);
        UIManager.Instance.waveText.text = "" + (UIManager.Instance.wave + 1);
    }
    void SpawnFast()
    {
        Spawn(spawnMonsters, 1);
    }
    void SpawnBig()
    {
        Spawn(spawnMonsters, 2);
    }
    public void SpawnRandomBoss()
    {
        Spawn(bossMonster, 0);
        UIManager.Instance.wave++;
        CostManager.Instance.costInc += 10;
        for (int i = 0; i < spawnMonsters.Count; i++)
        {
            spawnMonsters[i].GetComponent<MonsterStateManager>().health *= 2;
        }
        for (int i = 0; i < bossMonster.Count; i++)
        {
            bossMonster[i].GetComponent<MonsterStateManager>().health *= 2;
        }
        CancelInvoke();
    }
    void ValueChanges()
    {
        for (int i = 0; i < monsterHealth.Count; i++)
        {
            spawnMonsters[i].GetComponent<MonsterStateManager>().health = monsterHealth[i];
        }
        for (int i = 0; i < bossHealth.Count; i++)
        {
            bossMonster[i].GetComponent<MonsterStateManager>().health = bossHealth[i];
        }
    }
    void Spawn(List <GameObject> objList, int index)
    {
        var monster = Instantiate(objList[index], spawnPoint.position, Quaternion.identity);
        WaveControl.Instance.monsters.Add(monster);
        UIManager.Instance.CountAdd();
    }
}
