using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterDieState : MonsterBaseState
{
    //public delegate void Wave();
    //public static event Wave wave;
    public override void EnterState(MonsterStateManager monster)
    {
        //if (monster.destroy)
        //{
        //    CostManager.Instance.KillMonster(monster.costIncrease);
        //    Die(monster.gameObject);
        //}
        //else
        //{
        //    UIManager.Instance.LifeReduce();
        //    Die(monster.gameObject);
        //}
        UIManager.Instance.LifeReduce();
        DieMonster.Instance.Die(monster.gameObject);
    }
    public override void UpdateState(MonsterStateManager monster)
    {

    }
    public override void OnTriggerEnter(MonsterStateManager monster, Collider other)
    {

    }
    //void Die(GameObject obj)
    //{
    //    SpawnMonsters.Instance.monsters.Remove(obj);
    //    UIManager.Instance.CountRemove();
    //    if (WaveControl.Instance.waveFinish)
    //    {
    //        UIManager.Instance.time = 20;
    //        SpecialAttack.instance.playerSoldiers.Clear();

    //        for (int i = 0; i < SpawnSystem.Instance.soldiers.Count; i++)
    //        {
    //            if (SpawnSystem.Instance.soldiers[i] == null)
    //            {
    //                SpawnSystem.Instance.soldiers.RemoveAt(i);
    //                i--;
    //            }
    //        }
    //        SpawnSystem.Instance.ReAttack();
    //        CostManager.Instance.CostInc();
    //        wave();
    //    }
    //    Object.Destroy(obj);
    //}
}
