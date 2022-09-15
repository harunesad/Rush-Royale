using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterDieState : MonsterBaseState
{
    public override void EnterState(MonsterStateManager monster)
    {
        CostManager.Instance.KillMonster();
        WaveControl.Instance.monsters.Remove(monster.gameObject);
        UIManager.Instance.CountRemove();
        if (WaveControl.Instance.waveFinish)
        {
            UIManager.Instance.time = 20;
            SpecialAttack.instance.playerSoldiers.Clear();

            for (int i = 0; i < SpawnSystem.Instance.soldiers.Count; i++)
            {
                if (SpawnSystem.Instance.soldiers[i] == null)
                {
                    SpawnSystem.Instance.soldiers.RemoveAt(i);
                    i--;
                }
            }
            SpawnSystem.Instance.ReAttack();
        }
        Object.Destroy(monster.gameObject);
    }
    public override void UpdateState(MonsterStateManager monster)
    {

    }
    public override void OnCollisionEnter(MonsterStateManager monster, Collision collision)
    {

    }
}