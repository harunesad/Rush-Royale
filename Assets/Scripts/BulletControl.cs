using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletControl : MonoBehaviour
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
        attack = transform.parent.GetComponent<PlayerSoldier>().attack;
        attackSpeed = transform.parent.GetComponent<PlayerSoldier>().attackSpeed;
        transform.parent = null;

        target = compare.nearObj.gameObject;
    }
    void Update()
    {
        AttackMonster();
    }
    public void AttackMonster()
    {
        if (target == null)
        {
            Destroy(gameObject);
        }
        else
        {
            transform.LookAt(target.transform);
            transform.position = Vector3.MoveTowards(transform.position, target.transform.position, Time.deltaTime * attackSpeed);
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        MonsterStateManager monster = other.GetComponent<MonsterStateManager>();
        if (monster != null && monster.health > 0)
        {
            monster.health -= attack / monster.armor;
            Destroy(gameObject);
        }
        if (monster != null && monster.health <= 0)
        {
            monster.health = 0;
        }
    }
}
