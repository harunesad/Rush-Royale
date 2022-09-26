using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnMonsters : State, IState
{
    public static SpawnMonsters Instance;
    //public List<GameObject> spawnMonsters;
    [SerializeField] Transform spawnPoint;
    //public List<GameObject> bossMonster;
    [SerializeField] MonsterSoldiers soldiers;
    string methodNamee;
    float newTime;
    private void Awake()
    {
        Instance= this;
    }
    private void Start()
    {
        Invoke("SpawnSlow", 1);
        Invoke("SpawnFast", 5);
        Invoke("SpawnBig", 10);
    }
    public void ReSpawn(string methodName, float time)
    {
        methodNamee = methodName;
        newTime = time;
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
        Spawn(soldiers.spawnMonsters, 0);
        //UIManager.Instance.waveText.text = "" + (UIManager.Instance.wave + 1);
        //wave();
        Invoke("SpawnSlow", Random.Range(0.5f, 1.5f));
    }
    void SpawnFast()
    {
        Spawn(soldiers.spawnMonsters, 1);
        Invoke("SpawnFast", Random.Range(4f, 7f));
    }
    void SpawnBig()
    {
        Spawn(soldiers.spawnMonsters, 2);
        Invoke("SpawnBig", Random.Range(8f, 12f));
    }
    public void SpawnRandomBoss()
    {
        Spawn(soldiers.bossMonster, 0);
        //UIManager.Instance.wave++;
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
