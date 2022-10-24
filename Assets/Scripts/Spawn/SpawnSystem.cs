using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnSystem : GenericSingleton<SpawnSystem>
{
    public List<GameObject> soldiers;
    public List<GameObject> spawnPoints;
    public List<GameObject> spawnObj;
    Vector3 pos;
    public void ReAttack()
    {
        for (int i = 0; i < soldiers.Count; i++)
        {
            soldiers[i].GetComponent<BulletSpawn>().enabled = true;
        }
    }
    private void Start()
    {
        SpecialAttack.remove += Destroy;
        //DieMonster.bossDie += SoldierRemoveToList;
        DieMonster.bossDie += ReAttack;
    }
    void Destroy(int index)
    {
        Destroy(soldiers[index].gameObject);
        soldiers.RemoveAt(index);
    }
    public void Spawn()
    {
        if (spawnPoints.Count > 0 && CostManager.Instance.cost >= CostManager.Instance.costReduce && Time.timeScale == 1)
        {
            int randomIndex = Random.Range(0, spawnPoints.Count);
            for (int i = randomIndex; i < randomIndex + 1; i++)
            {
                pos = spawnPoints[i].transform.position;
            }

            CostManager.Instance.BuySoldier();

            int random = Random.Range(0, 4);
            var soldier = Instantiate(spawnObj[random], pos + Vector3.up * 0.225f, Quaternion.identity);
            soldiers.Add(soldier);
        }
    }
    public void SoldierRemoveToList()
    {
        for (int i = 0; i < soldiers.Count; i++)
        {
            if (soldiers[i] == null)
            {
                soldiers.RemoveAt(i);
                i--;
                Debug.Log("sadsda");
            }
            Debug.Log("aaaaaaa");
        }
    }
}
