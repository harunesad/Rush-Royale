using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnMonsters : GenericSingleton<SpawnMonsters>
{
    [SerializeField] List<GameObject> spawnMonsters;
    [SerializeField] Transform spawnPoint;
    public List<GameObject> monsters;
    [SerializeField] List<GameObject> bossMonster;

    float slowStartTime = 2, slowRepeatTime = 1;
    float fastStartTime = 4f, fastRepeatTime = 5;
    float bigStartTime = 11, bigRepeatTime = 10;
    float bossStartTime = 3, bossRepeatTime = 100;
    public float waveTime;
    public float bossWaveTime;

    public bool waveFinish = false;
    int wave = 1;
    private void Update()
    {
        WaveFinishState();
        WaveTimeInc();
        SpawnSlow();
        SpawnFast();
        SpawnBig();
        SpawnRandomBoss();
    }
    void WaveFinishState()
    {
        if (UIManager.Instance.time <= 0)
        {
            for (int i = 0; i < monsters.Count; i++)
            {
                waveFinish = true;
                Destroy(monsters[i]);
                UIManager.Instance.monsterCount.text = "";
            }
            monsters.Clear();
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
            bossWaveTime = 0;
            bossStartTime = 0;
        }
        else
        {
            bossWaveTime += Time.deltaTime;
            waveTime = 0;
            slowStartTime = 2;
            fastStartTime = 4;
            bigStartTime = 11;
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
            UIManager.Instance.waveText.text = "" + (UIManager.Instance.wave + 1);
            for (int i = 0; i < 10; i++)
            {
                if (UIManager.Instance.wave + 1 == i)
                {
                    i = i * i;
                    monster.GetComponent<Monster>().health = monster.GetComponent<Monster>().health * i;
                }
            }
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
            for (int i = 0; i < 10; i++)
            {
                if (UIManager.Instance.wave + 1 == i)
                {
                    i = i * i;
                    monster.GetComponent<Monster>().health = monster.GetComponent<Monster>().health * i;
                }
            }
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
            for (int i = 0; i < 10; i++)
            {
                if (UIManager.Instance.wave + 1 == i)
                {
                    i = i * i;
                    monster.GetComponent<Monster>().health = monster.GetComponent<Monster>().health * i;
                }
            }
        }
    }
    void SpawnRandomBoss()
    {
        if (bossWaveTime > bossStartTime && waveFinish)
        {
            bossStartTime += bossRepeatTime;
            var monster = Instantiate(bossMonster[0], spawnPoint.position, Quaternion.identity);
            UIManager.Instance.CountAdd();
            for (int i = 0; i < 10; i++)
            {
                if (UIManager.Instance.wave + 1 == i)
                {
                    i = i * i;
                    monster.GetComponent<Monster>().health = monster.GetComponent<Monster>().health * i;
                }
            }
            UIManager.Instance.wave++;
        }
    }
}
