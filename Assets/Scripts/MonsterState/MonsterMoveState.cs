using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterMoveState : MonsterBaseState
{
    GameObject targetPoint;
    public override void EnterState(MonsterStateManager monster)
    {
        targetPoint = GameObject.Find("TargetPoint");
        SpecialAttack.instance.Special(monster.specialAttack);
    }
    public override void UpdateState(MonsterStateManager monster)
    {
        if (monster.health > 0)
        {
            if (monster.transform.position.z < targetPoint.transform.position.z)
            {
                monster.transform.Translate(Vector3.forward * Time.deltaTime * monster.moveSpeed);
            }
            else
            {
                monster.healthText.gameObject.transform.parent.rotation = Quaternion.identity;
                monster.transform.rotation = Quaternion.Euler(0, 90, 0);
                monster.transform.Translate(Vector3.forward * Time.deltaTime * monster.moveSpeed);
            }
        }
        else
        {
            monster.SwitchState(monster.DieState);
        }
    }
    public override void OnCollisionEnter(MonsterStateManager monster, Collision collision)
    {
        GameObject other = collision.gameObject;
        if (other.CompareTag("Finish"))
        {
            monster.SwitchState(monster.DieState);
        }
    }
}
