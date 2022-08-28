using System;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSoldier : MonoBehaviour
{
    [SerializeField] PlayerState PlayerMode = PlayerState.Idle;

    public LayerMask checkLayers;
    public float checkRadius;
    public float attack;

    public Transform targetMonster;
    [SerializeField] GameObject finishPoint;
    [SerializeField] GameObject bullet;
    GameObject moveToBullet;
    protected enum PlayerState
    {
        Idle,
        AttackTarget,
    }
    private void Awake()
    {
        finishPoint = GameObject.Find("FinishPoint");
    }
    private void Update()
    {
        Collider[] colliders = Physics.OverlapSphere(transform.position, checkRadius, checkLayers);
        Array.Sort(colliders, new DistanceCompare(finishPoint.transform));
        foreach (var item in colliders)
        {
            targetMonster = item.transform;
            break;
        }
        if (targetMonster != null)
        {
            UpdateMonster();
        }
    }
    public void UpdateMonster()
    {
        switch (PlayerMode)
        {
            case PlayerState.Idle:
                PlayerMode = PlayerState.AttackTarget;
                break;
            case PlayerState.AttackTarget:
                //Lock Enemy
                if (moveToBullet == null)
                {
                    PlayerMode = PlayerState.Idle;
                }
                break;
        }
        DoAction();
    }
    public void DoAction()
    {
        switch (PlayerMode)
        {
            case PlayerState.Idle:
                var obj = Instantiate(bullet, transform.position, Quaternion.identity);
                obj.transform.parent = transform;
                moveToBullet = obj;
                break;
            case PlayerState.AttackTarget:
                //AttackMonster();
                //Debug.Log(moveToBullet.name);
                if (moveToBullet != null)
                {
                    moveToBullet.GetComponent<BulletControl>().AttackMonster();
                }
                break;
        }
    }
}
