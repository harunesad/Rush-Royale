using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnMonsters : GenericSingleton<SpawnMonsters>
{
    [SerializeField] List<GameObject> spawnMonsters;
    [SerializeField] Transform spawnPoint;
    [SerializeField] List<GameObject> monsters;

    float startTime = 2;
    float repeatTime = 1f;
    void Start()
    {
        InvokeRepeating("SpawnSlow", startTime, repeatTime);
        InvokeRepeating("SpawnFast", 4, 5);
        InvokeRepeating("SpawnBig", 11, 10);
    }
    void SpawnSlow()
    {
        var monster = Instantiate(spawnMonsters[0], spawnPoint.position, Quaternion.identity);
        monsters.Add(monster);
    }
    void SpawnFast()
    {
        var monster = Instantiate(spawnMonsters[1], spawnPoint.position, Quaternion.identity);
        monsters.Add(monster);
    }
    void SpawnBig()
    {
        var monster = Instantiate(spawnMonsters[2], spawnPoint.position, Quaternion.identity);
        monsters.Add(monster);
    }
}
