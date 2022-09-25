using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnMonsters : State, IState
{
    public static SpawnMonsters Instance;
    public List<GameObject> spawnMonsters;
    [SerializeField] Transform spawnPoint;
    public List<GameObject> bossMonster;
    string methodNamee;
    float newTime;
    int repeatTimee;
    float slowRepeat = 1, fastRepeat = 5, bigRepeat = 10;
    private void Awake()
    {
        Instance= this;
    }
    private void Start()
    {
        //InvokeRepeating("SpawnSlow", 2, slowRepeat);
        //InvokeRepeating("SpawnFast", 4, fastRepeat);
        //InvokeRepeating("SpawnBig", 11, bigRepeat);
        Invoke("SpawnSlow", 1);
        Invoke("SpawnFast", 5);
        Invoke("SpawnBig", 10);
    }
    public void ReSpawn(string methodName, float time)
    {
        methodNamee = methodName;
        newTime = time;
        //if (!IsInvoking(methodName))
        //{
        //    InvokeRepeating(methodName, time, repeatTime);
        //}
        Run(!IsInvoking(methodName));
    }
    public void ReSpawnObj()
    {
        ReSpawn("SpawnSlow", Random.Range(0.5f, 1.5f));
        ReSpawn("SpawnFast", Random.Range(4f, 7f));
        ReSpawn("SpawnBig", Random.Range(8f, 12f));
    }
    void SpawnSlow()
    {
        Spawn(spawnMonsters, 0);
        UIManager.Instance.waveText.text = "" + (UIManager.Instance.wave + 1);
        Invoke("SpawnSlow", Random.Range(0.5f, 1.5f));
        //slowRepeat = Random.Range(1, 2);
    }
    void SpawnFast()
    {
        Spawn(spawnMonsters, 1);
        //fastRepeat = Random.Range(4, 7);
        Invoke("SpawnFast", Random.Range(4f, 7f));
    }
    void SpawnBig()
    {
        Spawn(spawnMonsters, 2);
        //bigRepeat = Random.Range(9, 12);
        Invoke("SpawnBig", Random.Range(8f, 12f));
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
    public override void StateTrue()
    {
        Invoke(methodNamee, newTime);
    }
    public override void StateFalse()
    {
        return;
    }
}
