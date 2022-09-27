using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class MonsterMoveState : MonsterBaseState
{
    GameObject finish;
    public delegate void Special(int choose);
    public static event Special special;
    public override void EnterState(MonsterStateManager monster)
    {
        finish = GameObject.Find("FinishPoint");
        //SpecialAttack.instance.Special(monster.specialAttack);
        special(monster.specialAttack);
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
        if (otherObj.layer == 19)
        {
            monster.transform.GetChild(0).rotation = Quaternion.Euler(0, -90, 0);
            monster.transform.rotation = Quaternion.Euler(0, 90, 0);
        }
        if (otherObj.layer == 18)
        {
            monster.destroy = false;
            monster.SwitchState(monster.DieState);
        }
    }
}
