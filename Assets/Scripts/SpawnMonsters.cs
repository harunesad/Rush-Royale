using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnMonsters : GenericSingleton<SpawnMonsters>
{
    [SerializeField] List<GameObject> spawnMonsters;
    [SerializeField] Transform spawnPoint;
    [SerializeField] List<GameObject> monsters;

    public float slowStartTime = 2, slowRepeatTime = 1;
    float fastStartTime = 4f, fastRepeatTime = 5;
    float bigStartTime = 11, bigRepeatTime = 10;
    public float waveTime;

    bool waveFinish = false;
    private void Update()
    {
        WaveFinishState();
        WaveTimeInc();
        SpawnSlow();
        SpawnFast();
        SpawnBig();
    }
    void WaveFinishState()
    {
        if (UIManager.Instance.time <= 0)
        {
            for (int i = 0; i < monsters.Count; i++)
            {
                waveFinish = true;
                Destroy(monsters[i]);
            }
        }
        else
        {
            waveFinish = false;
        }
    }
    void WaveTimeInc()
    {
        if (!waveFinish)
        {
            waveTime += Time.deltaTime;
        }
        else
        {
            waveTime = 0;
        }
    }
    void SpawnSlow()
    {
        if (waveTime >= slowStartTime && !waveFinish)
        {
            slowStartTime += slowRepeatTime;
            var monster = Instantiate(spawnMonsters[0], spawnPoint.position, Quaternion.identity);
            monsters.Add(monster);
            UIManager.Instance.CountAdd();
        }
    }
    void SpawnFast()
    {
        if (waveTime >= fastStartTime && !waveFinish)
        {
            fastStartTime += fastRepeatTime;
            var monster = Instantiate(spawnMonsters[1], spawnPoint.position, Quaternion.identity);
            monsters.Add(monster);
            UIManager.Instance.CountAdd();
        }
    }
    void SpawnBig()
    {
        if (waveTime >= bigStartTime && !waveFinish)
        {
            bigStartTime += bigRepeatTime;
            var monster = Instantiate(spawnMonsters[2], spawnPoint.position, Quaternion.identity);
            monsters.Add(monster);
            UIManager.Instance.CountAdd();
        }
    }
}
