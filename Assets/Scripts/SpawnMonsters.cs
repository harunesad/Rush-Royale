using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnMonsters : GenericSingleton<SpawnMonsters>
{
    [SerializeField] GameObject spawnMonster;
    [SerializeField] Transform spawnPoint;
    [SerializeField] List<GameObject> monsters;

    float startTime = 2;
    float repeatTime = 1f;
    void Start()
    {
        InvokeRepeating("Spawn", startTime, repeatTime);
    }
    void Spawn()
    {
        var monster = Instantiate(spawnMonster, spawnPoint.position, Quaternion.identity);
        monsters.Add(monster);
    }
}
