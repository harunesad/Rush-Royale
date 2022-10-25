using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DieMonster : MonoBehaviour
{
    public static DieMonster Instance;
    public delegate void BossDie();
    public static event BossDie bossDie;
    private void Awake()
    {
        Instance = this;
    }
    public void Die(GameObject obj)
    {
        SpawnMonsters.Instance.monsters.Remove(obj);
        UIManager.Instance.CountRemove();
        if (WaveControl.Instance.waveFinish)
        {
            //UIManager.Instance.time = 20;
            //SpecialAttack.instance.playerSoldiers.Clear();

            //for (int i = 0; i < SpawnSystem.Instance.soldiers.Count; i++)
            //{
            //    if (SpawnSystem.Instance.soldiers[i] == null)
            //    {
            //        SpawnSystem.Instance.soldiers.RemoveAt(i);
            //        i--;
            //    }
            //}
            //SpawnSystem.Instance.SoldierRemoveToList();
            //SpawnSystem.Instance.ReAttack();
            //CostManager.Instance.CostInc();
            bossDie();
        }
        Destroy(obj);
    }
}
