using System;
using System.Collections.Generic;
using UnityEngine;

public class BulletSpawn : MonoBehaviour
{
    public float attack;
    public float attackSpeed;

    [SerializeField] GameObject bullet;
    Compare compare;
    private void Start()
    {
        compare = GameObject.Find("FinishPoint").GetComponent<Compare>();
        InvokeRepeating("SpawnBullet", 1, 0.25f);
    }
    public void SpawnBullet()
    {
        if (compare.nearObj != null)
        {
            var obj = Instantiate(bullet, transform.position, Quaternion.identity);
            obj.transform.parent = transform;
        }
    }
}
