using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletControl : MonoBehaviour
{
    public float attack;
    //public Transform parent;
    public float attackSpeed;
    PlayerSoldier soldier;
    public GameObject target;
    public Transform parent;
    private void Awake()
    {
        //parent = transform.parent;
    }
    void Start()
    {
        parent = transform.parent;
        soldier = transform.parent.GetComponent<PlayerSoldier>();
        attack = soldier.attack;
        target = soldier.targetMonster.gameObject;
    }
    void Update()
    {
        if (target == null || parent == null)
        {
            Destroy(gameObject);
        }
    }
    public void AttackMonster()
    {
        //Transform target = parent.GetComponent<PlayerSoldier>().targetMonster;
        transform.LookAt(soldier.targetMonster.transform);
        if (transform.parent != null)
        {
            transform.parent = null;
        }
        transform.position = Vector3.MoveTowards(transform.position, soldier.targetMonster.position, Time.deltaTime * attackSpeed);
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Monster") && other.GetComponent<Monster>().health > 0)
        {
            Monster monster = other.GetComponent<Monster>();
            monster.health -= attack / monster.armor;
            Destroy(gameObject, 0.5f);
        }
    }
}
