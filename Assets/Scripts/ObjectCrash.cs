using System;
using System.Collections.Generic;
using UnityEngine;

public class ObjectCrash : MonoBehaviour
{
    public static ObjectCrash Instance;
    public bool isMerge = false;
    public GameObject crashObj;
    public GameObject near;
    Transform nearObj;
    [SerializeField] LayerMask checkLayers;
    private void Awake()
    {
        Instance = this;
    }
    private void Update()
    {
        Collider[] colliders = Physics.OverlapSphere(transform.position, Placement.instance.checkRadius, checkLayers);
        Array.Sort(colliders, new DistanceCompare(transform));
        foreach (var item in colliders)
        {
            nearObj = item.transform;
            near = nearObj.gameObject;
            break;
        }
    }
    private void OnTriggerStay(Collider other)
    {
        if (gameObject.GetComponent<Placement>().isClick)
        {
            if (gameObject.tag == other.tag)
            {
                if (crashObj == null)
                {
                    crashObj = other.gameObject;
                }
                if (crashObj != near)
                {
                    //isMerge = true;
                    crashObj = null;
                    Debug.Log("sadsasda");
                }
                //crashObj = null;

                isMerge = true;
            }
            else
            {
                isMerge = false;
            }
        }
    }
    private void OnTriggerExit(Collider other)
    {
        isMerge = false;
        crashObj = null;
    }
}