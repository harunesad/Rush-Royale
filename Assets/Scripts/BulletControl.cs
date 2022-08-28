using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletControl : MonoBehaviour
{
    public float attack;
    //public Transform parent;
    public float attackSpeed;
    PlayerSoldier soldier;
    private void Awake()
    {
        //parent = transform.parent;
    }
    void Start()
    {
        soldier = transform.parent.GetComponent<PlayerSoldier>();
        attack = soldier.attack;
    }
    void Update()
    {
        
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
        if (other.gameObject.CompareTag("Monster"))
        {
            Monster monster = other.GetComponent<Monster>();
            monster.health -= attack / monster.armor;
            Destroy(gameObject);
        }
    }
}
