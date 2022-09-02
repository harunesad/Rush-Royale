using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpecialAttack : MonoBehaviour
{
    public static SpecialAttack instance;
    public List<GameObject> playerSoldiers;
    private void Awake()
    {
        instance = this;
    }
    public void Special(int special)
    {
        switch (special)
        {
            case 0:
                break;
            case 1:
                int playerSol = Random.Range(0, SpawnSystem.Instance.soldiers.Count);
                Destroy(SpawnSystem.Instance.soldiers[playerSol].gameObject);
                SpawnSystem.Instance.soldiers.RemoveAt(playerSol);
                break;
            case 2:
                if (playerSoldiers.Count == 0)
                {
                    for (int i = 0; i < SpawnSystem.Instance.soldiers.Count; i++)
                    {
                        playerSoldiers.Add(SpawnSystem.Instance.soldiers[i]);
                    }
                }
                int sol = Random.Range(0, playerSoldiers.Count);
                playerSoldiers[sol].GetComponent<PlayerSoldier>().enabled = false;
                playerSoldiers.RemoveAt(sol);
                break;
            case 3:
                UpgradeRemove(SpawnSystem.Instance.divideObj, 0, 10);
                UpgradeRemove(SpawnSystem.Instance.minusObj, 1, 9);
                UpgradeRemove(SpawnSystem.Instance.plusObj, 2, 8);
                UpgradeRemove(SpawnSystem.Instance.starObj, 3, 7);
                break;
            case 4:
                RemoveLevel(SpawnSystem.Instance.divideObj);
                RemoveLevel(SpawnSystem.Instance.minusObj);
                RemoveLevel(SpawnSystem.Instance.plusObj);
                RemoveLevel(SpawnSystem.Instance.starObj);
                break;
            default:
                break;
        }
    }
    void UpgradeRemove(List<GameObject> objects, int index, int layer)
    {
        if (UpgradeSystem.Instance.upgradeCost[index] >= 200)
        {
            for (int i = 0; i < SpawnSystem.Instance.soldiers.Count; i++)
            {
                if (SpawnSystem.Instance.soldiers[i].layer == layer)
                {
                    SpawnSystem.Instance.soldiers[i].GetComponent<PlayerSoldier>().attack /= 2;
                }
            }
            for (int i = 0; i < objects.Count; i++)
            {
                objects[i].GetComponent<PlayerSoldier>().attack /= 2;
            }

            UpgradeSystem.Instance.upgradeCost[index] -= 100;
            UIManager.Instance.upgradeText[index].text = "" + UpgradeSystem.Instance.upgradeCost[index];
        }
    }
    void RemoveLevel(List<GameObject> obj)
    {
        for (int i = 0; i < SpawnSystem.Instance.soldiers.Count; i+=2)
        {
            for (int j = 0; j < obj.Count; j++)
            {
                if (SpawnSystem.Instance.soldiers[i] != null && SpawnSystem.Instance.soldiers[i].tag == obj[j].tag && SpawnSystem.Instance.soldiers[i].layer == obj[j].layer)
                {
                    if (j > 0)
                    {
                        float posx = SpawnSystem.Instance.soldiers[i].transform.position.x;
                        float posz = SpawnSystem.Instance.soldiers[i].transform.position.z;
                        var spawnObj = Instantiate(obj[j - 1], new Vector3(posx, 0.225f, posz), transform.rotation);
                        Destroy(SpawnSystem.Instance.soldiers[i].gameObject);
                        SpawnSystem.Instance.soldiers.Add(spawnObj);
                        SpawnSystem.Instance.soldiers[i] = SpawnSystem.Instance.soldiers[SpawnSystem.Instance.soldiers.Count - 1];
                        SpawnSystem.Instance.soldiers.RemoveAt(SpawnSystem.Instance.soldiers.Count - 1);
                    }
                    else
                    {
                        Destroy(SpawnSystem.Instance.soldiers[i].gameObject);
                        //SpawnSystem.Instance.soldiers.RemoveAt(i);
                    }
                }
            }
        }
    }
    private void Update()
    {
        //for (int i = 0; i < SpawnSystem.Instance.soldiers.Count; i++)
        //{
        //    if (SpawnSystem.Instance.soldiers[i] == null)
        //    {
        //        SpawnSystem.Instance.soldiers.RemoveAt(i);
        //    }
        //}
    }
}
