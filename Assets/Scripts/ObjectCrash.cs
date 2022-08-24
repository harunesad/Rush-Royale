using System;
using System.Collections.Generic;
using UnityEngine;

public class ObjectCrash : MonoBehaviour
{
    public static ObjectCrash Instance;
    public bool isMerge = false;
    public bool isCrash = false;
    public GameObject near;
    Transform nearObj;
    [SerializeField] LayerMask checkLayers;
    public List<GameObject> others;
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

    private void OnTriggerEnter(Collider other)
    {
        if (gameObject.GetComponent<Placement>().isClick)
        {
            isCrash = true;
            Debug.Log("af");
            if (other.gameObject != null)
            {
                others.Add(other.gameObject);
            }
            for (int i = 0; i < others.Count; i++)
            {
                if (gameObject.GetComponent<Placement>().myLayer == others[i].layer && gameObject.tag == others[i].tag)
                {
                    isMerge = true;
                }
            }
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (others.Count > 0)
        {
            others.Remove(other.gameObject);
        }
        else
        {
            isCrash = false;
        }
        for (int i = 0; i < others.Count; i++)
        {
            if (gameObject.GetComponent<Placement>().myLayer != others[i].layer || gameObject.tag != others[i].tag)
            {
                isMerge = false;
            }
        }
    }
}
