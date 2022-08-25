using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monster : MonoBehaviour
{
    MonsterState MonsterMode = MonsterState.Idle;
    public float health;
    public float armor;
    public float moveSpeed;

    [SerializeField] GameObject targetPoint;
    [SerializeField] GameObject finishPoint;
    protected enum MonsterState
    {
        Idle,
        MoveTarget,
        Die,
    }
    private void Start()
    {
        targetPoint = GameObject.Find("TargetPoint");
        finishPoint = GameObject.Find("FinishPoint");
    }
    private void Update()
    {
        UpdateMonster();
    }
    public void UpdateMonster()
    {
        switch (MonsterMode)
        {
            case MonsterState.Idle:
                if (health <= 0)
                {
                    Destroy(gameObject, 1);
                }
                else
                {
                    MonsterMode = MonsterState.MoveTarget;
                }
                break;
            case MonsterState.MoveTarget:
                if (health <= 0)
                {
                    MonsterMode = MonsterState.Die;
                }
                break;
            case MonsterState.Die:
                MonsterMode = MonsterState.Idle;
                break;
        }
        DoAction();
    }
    public void DoAction()
    {
        switch (MonsterMode)
        {
            case MonsterState.MoveTarget:
                MoveMonster();
                break;
            case MonsterState.Die:
                Died();
                break;
        }
    }
    void MoveMonster()
    {
        if (transform.position.z < targetPoint.transform.position.z)
        {
            transform.Translate(Vector3.forward * Time.deltaTime);
        }
        else
        {
            transform.rotation = Quaternion.Euler(0, 90, 0);
            transform.Translate(Vector3.forward * Time.deltaTime);
        }
    }
    void Died()
    {
        CostManager.Instance.KillMonster();
    }
}
