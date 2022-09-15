using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Compare : MonoBehaviour
{
    public LayerMask checkLayers;
    public float checkRadius;
    public Transform nearObj;
    void Update()
    {
        ComparePos();
    }
    public void ComparePos()
    {
        Collider[] colliders = Physics.OverlapSphere(transform.position, checkRadius, checkLayers);
        Array.Sort(colliders, new DistanceCompare(transform));
        foreach (var item in colliders)
        {
            Debug.Log(item.transform.gameObject.name);
            nearObj = item.transform;
            break;
        }
    }
}
