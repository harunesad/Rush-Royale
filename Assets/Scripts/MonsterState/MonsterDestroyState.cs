using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterDestroyState : MonsterBaseState
{
    public override void EnterState(MonsterStateManager monster)
    {
        CostManager.Instance.KillMonster(monster.costIncrease);
        DieMonster.Instance.Die(monster.gameObject);
    }

    public override void OnTriggerEnter(MonsterStateManager monster, Collider other)
    {

    }

    public override void UpdateState(MonsterStateManager monster)
    {

    }
}
