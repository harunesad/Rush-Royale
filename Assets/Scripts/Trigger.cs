using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trigger : MonoBehaviour
{
    public bool isEmpty = true;
    private void OnTriggerEnter(Collider other)
    {
        if (!other.gameObject.CompareTag("Untagged"))
        {
            other.gameObject.layer = other.gameObject.GetComponent<PlayerStateManager>().myLayer;
            isEmpty = false;
            gameObject.layer = 0;
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
            gameObject.layer = 3;
            Debug.Log(isEmpty);
            if (!SpawnSystem.Instance.spawnPoints.Contains(gameObject))
            {
                SpawnSystem.Instance.spawnPoints.Add(gameObject);
            }
        }
    }
}
