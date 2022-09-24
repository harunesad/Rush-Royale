using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Compare : MonoBehaviour
{
    public LayerMask layerPos;
    public LayerMask layerObj;
    public float checkRadius;
    public Transform nearPos;
    public Transform nearObj;
    void Update()
    {
        ComparePos();
        CompareObj();
    }
    public void ComparePos()
    {
        Collider[] colliders = Physics.OverlapSphere(transform.position, checkRadius, layerPos);
        Array.Sort(colliders, new DistanceCompare(transform));
        foreach (var item in colliders)
        {
            Debug.Log(item.transform.gameObject.name);
            nearPos = item.transform;
            break;
        }
    }
    public void CompareObj()
    {
        Collider[] colliders = Physics.OverlapSphere(transform.position, checkRadius, layerObj);
        Array.Sort(colliders, new DistanceCompare(transform));
        foreach (var item in colliders)
        {
            Debug.Log(item.transform.gameObject.name);
            nearObj = item.transform;
            break;
        }
    }
}
