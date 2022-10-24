using System;
using System.Collections.Generic;
using UnityEngine;

public class BulletSpawn : State , IState
{
    public float attack;
    public float attackSpeed;
    public float spawnSpeed;

    [SerializeField] GameObject bullet;
    Compare compare;
    private void Start()
    {
        compare = GameObject.Find("Compare").GetComponent<Compare>();
        InvokeRepeating("SpawnBullet", 1, spawnSpeed);
    }
    public void SpawnBullet()
    {
        //if (compare.nearObj != null)
        //{
        //var obj = Instantiate(bullet, transform.position, Quaternion.identity);
        //obj.transform.parent = transform;
        //}
        Run(compare.nearMonster != null);
    }

    public override void StateTrue()
    {
        var obj = Instantiate(bullet, transform.position, Quaternion.identity);
        obj.transform.parent = transform;
    }

    public override void StateFalse()
    {
        return;
    }
}
