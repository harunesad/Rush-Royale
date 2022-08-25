using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trigger : MonoBehaviour
{
    public bool isEmpty = true;
    private void OnTriggerEnter(Collider other)
    {
        if (!other.gameObject.CompareTag("Untagged") && !Placement.instance.isClick)
        {
            other.gameObject.layer = other.gameObject.GetComponent<Placement>().myLayer;
            isEmpty = false;
            Debug.Log("a");
            if (SpawnSystem.Instance.spawnPoints.Contains(gameObject))
            {
                SpawnSystem.Instance.spawnPoints.Remove(gameObject);
            }
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (!other.gameObject.CompareTag("Untagged"))
        {
            isEmpty = true;
            Debug.Log(isEmpty);
            if (!SpawnSystem.Instance.spawnPoints.Contains(gameObject))
            {
                SpawnSystem.Instance.spawnPoints.Add(gameObject);
            }
        }
    }
}
