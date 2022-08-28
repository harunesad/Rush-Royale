using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnSystem : GenericSingleton<SpawnSystem>
{
    public List<GameObject> soldiers;
    public List<GameObject> spawnPoints;
    public List<GameObject> starObj;
    public List<GameObject> plusObj;
    public List<GameObject> minusObj;
    public List<GameObject> divideObj;
    [SerializeField] List<GameObject> spawnObj;

    //[SerializeField] GameObject spawnStar;
    //[SerializeField] GameObject spawnPlus;
    //[SerializeField] GameObject spawnMinus;
    //[SerializeField] GameObject spawnDivide;
    Vector3 pos;
    private void Update()
    {
        //if (!SpawnMonsters.Instance.waveFinish)
        //{
        //    for (int i = 0; i < soldiers.Count; i++)
        //    {
        //        soldiers[i].GetComponent<PlayerSoldier>().enabled = true;
        //    }
        //}
    }
    public void ReAttack()
    {
        for (int i = 0; i < soldiers.Count; i++)
        {
            soldiers[i].GetComponent<PlayerSoldier>().enabled = true;
        }
    }
    public void Spawn()
    {
        //int randomIndex = Random.Range(0, spawnPoints.Count);
        //if (spawnPoints.Count > 0)
        //{
        //    for (int i = randomIndex; i < randomIndex + 1; i++)
        //    {
        //        pos = spawnPoints[i].transform.position;
        //    }
        //}
        //if (spawnPoints.Count > 0 && CostManager.Instance.cost >= CostManager.Instance.costReduce)
        //{
        //    int random = Random.Range(0, 4);
        //    CostManager.Instance.BuySoldier();
        //    Instantiate(spawnObj[random], pos + Vector3.up * 0.225f, Quaternion.identity);
        //}
        if (spawnPoints.Count > 0 && CostManager.Instance.cost >= CostManager.Instance.costReduce)
        {
            int randomIndex = Random.Range(0, spawnPoints.Count);
            for (int i = randomIndex; i < randomIndex + 1; i++)
            {
                pos = spawnPoints[i].transform.position;
            }

            int random = Random.Range(0, 4);
            CostManager.Instance.BuySoldier();
            var soldier = Instantiate(spawnObj[random], pos + Vector3.up * 0.225f, Quaternion.identity);
            soldiers.Add(soldier);
        }
    }
}
