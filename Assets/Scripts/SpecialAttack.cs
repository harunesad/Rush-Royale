using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpecialAttack : MonoBehaviour
{
    [SerializeField] PlayerSoldiers soldiers;
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
                playerSoldiers[sol].GetComponent<BulletSpawn>().enabled = false;
                playerSoldiers.RemoveAt(sol);
                break;
            case 3:
                UpgradeRemove(soldiers.divideObj, 0, 10);
                UpgradeRemove(soldiers.minusObj, 1, 9);
                UpgradeRemove(soldiers.plusObj, 2, 8);
                UpgradeRemove(soldiers.starObj, 3, 7);
                break;
            case 4:
                RemoveLevel(soldiers.divideObj);
                RemoveLevel(soldiers.minusObj);
                RemoveLevel(soldiers.plusObj);
                RemoveLevel(soldiers.starObj);
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
                    SpawnSystem.Instance.soldiers[i].GetComponent<BulletSpawn>().attack /= 2;
                }
            }
            for (int i = 0; i < objects.Count; i++)
            {
                objects[i].GetComponent<BulletSpawn>().attack /= 2;
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
                        SpawnSystem.Instance.spawnPoints.Add(SpawnSystem.Instance.soldiers[i].GetComponent<PlayerStateManager>().groundObj);
                        Destroy(SpawnSystem.Instance.soldiers[i].gameObject);
                        GameObject ground = SpawnSystem.Instance.soldiers[i].GetComponent<PlayerStateManager>().groundObj;
                        ground.GetComponent<Trigger>().isEmpty = true;
                        ground.layer = 3;
                    }
                }
            }
        }
    }
}
