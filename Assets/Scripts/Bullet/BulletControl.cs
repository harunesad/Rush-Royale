using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletControl : State, IState
{
    public float attack;
    public float attackSpeed;
    public GameObject target;
    Compare compare;
    private void Awake()
    {
        compare = GameObject.Find("FinishPoint").GetComponent<Compare>();
    }
    void Start()
    {
        attack = transform.parent.GetComponent<BulletSpawn>().attack;
        attackSpeed = transform.parent.GetComponent<BulletSpawn>().attackSpeed;
        transform.parent = null;

        target = compare.nearObj.gameObject;
    }
    void Update()
    {
        Run(target == null);
        //AttackMonster(target ? target : gameObject);
    }
    public void AttackMonster(GameObject obj)
    {
        if (target == null)
        {
            Destroy(gameObject);
        }
        transform.LookAt(obj.transform);
        transform.position = Vector3.MoveTowards(transform.position, obj.transform.position, Time.deltaTime * attackSpeed);
    }
    private void OnTriggerEnter(Collider other)
    {
        MonsterStateManager monster = other.GetComponent<MonsterStateManager>();
        if (monster != null && monster.health > 0)
        {
            monster.health -= attack / monster.armor;
            Destroy(gameObject);
        }
    }

    public override void StateTrue()
    {
        Destroy(gameObject);
    }

    public override void StateFalse()
    {
        transform.LookAt(target.transform);
        transform.position = Vector3.MoveTowards(transform.position, target.transform.position, Time.deltaTime * attackSpeed);

    }
}
