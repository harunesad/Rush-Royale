using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trigger : MonoBehaviour
{
    public bool isEmpty = true;
    LayerMask mask;
    private void OnTriggerEnter(Collider other)
    {
        if (!other.gameObject.CompareTag("Untagged") && !Placement.instance.isClick)
        {
            other.gameObject.layer = other.gameObject.GetComponent<Placement>().myLayer;
            isEmpty = false;
            Debug.Log("a");
            if (SpawnSystem.instance.spawnPoints.Contains(gameObject))
            {
                SpawnSystem.instance.spawnPoints.Remove(gameObject);
            }
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (!other.gameObject.CompareTag("Untagged"))
        {
            isEmpty = true;
            Debug.Log(isEmpty);
            if (!SpawnSystem.instance.spawnPoints.Contains(gameObject))
            {
                SpawnSystem.instance.spawnPoints.Add(gameObject);
            }
        }
    }
}
