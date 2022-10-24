using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Compare : MonoBehaviour
{
    public LayerMask layerGround;
    public LayerMask layerObject;
    public LayerMask layerMonster;
    public float checkRadius;
    public Transform nearGround;
    public Transform nearObject;
    public Transform nearMonster;
    public Transform soldier;
    public Transform finishObject;
    void Update()
    {
        CompareMonster();
    }
    public void CompareGround()
    {
        Collider[] colliders = Physics.OverlapSphere(soldier.position, checkRadius, layerGround);
        Array.Sort(colliders, new DistanceCompare(soldier));
        foreach (var item in colliders)
        {
            Debug.Log(item.transform.gameObject.name);
            nearGround = item.transform;
            break;
        }
    }
    public void CompareObject()
    {
        Collider[] colliders = Physics.OverlapSphere(soldier.position, checkRadius, layerObject);
        Array.Sort(colliders, new DistanceCompare(soldier));
        foreach (var item in colliders)
        {
            Debug.Log(item.transform.gameObject.name);
            nearObject = item.transform;
            break;
        }
    }
    public void CompareMonster()
    {
        Collider[] colliders = Physics.OverlapSphere(finishObject.position, checkRadius, layerMonster);
        Array.Sort(colliders, new DistanceCompare(finishObject));
        foreach (var item in colliders)
        {
            Debug.Log(item.transform.gameObject.name);
            nearMonster = item.transform;
            break;
        }

    }
}
