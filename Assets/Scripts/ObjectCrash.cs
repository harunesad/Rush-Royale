using System;
using System.Collections.Generic;
using UnityEngine;

public class ObjectCrash : MonoBehaviour
{
    public bool isMerge = false;
    public bool isCrash = false;
    [SerializeField] LayerMask checkLayers;
    public List<GameObject> others;
    public GameObject crashObj;
    private void OnTriggerEnter(Collider other)
    {
        if (gameObject.GetComponent<Placement>().isClick && !other.CompareTag("Untagged"))
        {
            //if (other.gameObject != null)
            //{
            //    others.Add(other.gameObject);
            //}
            others.Add(other.gameObject);
        }
    }
    private void OnTriggerStay(Collider other)
    {
        if (gameObject.GetComponent<Placement>().isClick)
        {
            isCrash = true;
            for (int i = 0; i < others.Count; i++)
            {
                if (gameObject.GetComponent<Placement>().myLayer == others[i].layer && gameObject.tag == others[i].tag)
                {
                    isMerge = true;
                    crashObj = others[i];
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
        if (others.Count == 0)
        {
            isCrash = false;
        }
        if (crashObj == other.gameObject)
        {
            isMerge = false;
        }
    }
}
