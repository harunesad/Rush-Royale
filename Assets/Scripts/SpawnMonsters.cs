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

    public List<float> monsterHealth;
    public List<float> bossHealth;
    public bool waveFinish = false;
    private void Start()
    {
        for (int i = 0; i < spawnMonsters.Count; i++)
        {
            monsterHealth.Add(i);
            monsterHealth[i] = spawnMonsters[i].GetComponent<Monster>().health;
        }
        for (int i = 0; i < bossMonster.Count; i++)
        {
            bossHealth.Add(i);
            bossHealth[i] = bossMonster[i].GetComponent<Monster>().health;
        }
    }
    private void Update()
    {
        Application.quitting += ValueChanges;
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
    void SpawnRandomBoss()
    {
        if (bossWaveTime > bossStartTime && waveFinish)
        {
            bossStartTime += bossRepeatTime;
            var monster = Instantiate(bossMonster[0], spawnPoint.position, Quaternion.identity);
            UIManager.Instance.CountAdd();
            UIManager.Instance.wave++;
            for (int i = 0; i < spawnMonsters.Count; i++)
            {
                spawnMonsters[i].GetComponent<Monster>().health *= 2;
            }
            for (int i = 0; i < bossMonster.Count; i++)
            {
                bossMonster[i].GetComponent<Monster>().health *= 2;
            }
        }
    }
    void ValueChanges()
    {
        for (int i = 0; i < monsterHealth.Count; i++)
        {
            spawnMonsters[i].GetComponent<Monster>().health = monsterHealth[i];
        }
        for (int i = 0; i < bossHealth.Count; i++)
        {
            bossMonster[i].GetComponent<Monster>().health = bossHealth[i];
        }
    }
}
