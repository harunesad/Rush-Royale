using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnSystem : GenericSingleton<SpawnSystem>
{
    public List<GameObject> soldiers;
    public List<GameObject> spawnPoints;
    //public List<GameObject> starObj;
    //public List<GameObject> plusObj;
    //public List<GameObject> minusObj;
    //public List<GameObject> divideObj;
    [SerializeField] List<GameObject> spawnObj;
    Vector3 pos;
    public void ReAttack()
    {
        for (int i = 0; i < soldiers.Count; i++)
        {
            soldiers[i].GetComponent<BulletSpawn>().enabled = true;
        }
    }
    public void Spawn()
    {
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
