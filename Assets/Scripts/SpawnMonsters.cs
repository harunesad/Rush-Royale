using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnMonsters : GenericSingleton<SpawnMonsters>
{
    public List<GameObject> spawnMonsters;
    [SerializeField] Transform spawnPoint;
    public List<GameObject> bossMonster;
    private void Start()
    {
        InvokeRepeating("SpawnSlow", 2, 1);
        InvokeRepeating("SpawnFast", 4, 5);
        InvokeRepeating("SpawnBig", 11, 10);
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
        CancelInvoke();
    }
    void Spawn(List <GameObject> objList, int index)
    {
        var monster = Instantiate(objList[index], spawnPoint.position, Quaternion.identity);
        WaveControl.Instance.monsters.Add(monster);
        UIManager.Instance.CountAdd();
    }
}
