using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trigger : MonoBehaviour
{
    public bool isEmpty = true;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player") && !Placement.instance.isClick)
        {
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
        if (other.gameObject.CompareTag("Player"))
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
