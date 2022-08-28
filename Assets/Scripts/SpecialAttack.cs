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
            default:
                break;
        }
    }
}
