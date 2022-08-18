using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectCrash : MonoBehaviour
{
    public static ObjectCrash Instance;
    public bool isMerge = false;
    public GameObject crashObj;
    private void Awake()
    {
        Instance = this;
    }
    private void OnTriggerEnter(Collider other)
    {
        if (gameObject.tag == other.tag)
        {
            crashObj = gameObject;
            isMerge = true;
        }
        else
        {
            isMerge = false;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        isMerge = false;
    }
}
