using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterMoveState : MonsterBaseState
{
    public override void EnterState(MonsterStateManager monster)
    {
        SpecialAttack.instance.Special(monster.specialAttack);
    }
    public override void UpdateState(MonsterStateManager monster)
    {
        if (monster.health <= 0)
        {
            monster.destroy = true;
            monster.SwitchState(monster.DieState);
        }
        monster.transform.Translate(Vector3.forward * Time.deltaTime * monster.moveSpeed);
    }
    public override void OnTriggerEnter(MonsterStateManager monster, Collider other)
    {
        GameObject otherObj = other.gameObject;
        if (otherObj.CompareTag("Target"))
        {
            monster.transform.GetChild(0).rotation = Quaternion.Euler(0, -90, 0);
            monster.transform.rotation = Quaternion.Euler(0, 90, 0);
        }
        if (otherObj.CompareTag("Finish"))
        {
            monster.destroy = false;
            monster.SwitchState(monster.DieState);
        }
    }
}
