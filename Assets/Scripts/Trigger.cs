using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trigger : MonoBehaviour
{
    public bool isEmpty = true;
    private void OnTriggerEnter(Collider other)
    {
        //if (!other.gameObject.CompareTag("Untagged"))
        //{
        //    other.gameObject.layer = other.gameObject.GetComponent<PlayerStateManager>().myLayer;
        //    isEmpty = false;
        //    gameObject.layer = 0;
        //    Debug.Log("a");
        //    if (SpawnSystem.Instance.spawnPoints.Contains(gameObject))
        //    {
        //        SpawnSystem.Instance.spawnPoints.Remove(gameObject);
        //    }
        //}
        TriggerControl(other, false, 2, 0, true);
    }
    private void OnTriggerExit(Collider other)
    {
        //if (!other.gameObject.CompareTag("Untagged"))
        //{
        //    isEmpty = true;
        //    gameObject.layer = 3;
        //    Debug.Log(isEmpty);
        //    if (!SpawnSystem.Instance.spawnPoints.Contains(gameObject))
        //    {
        //        SpawnSystem.Instance.spawnPoints.Add(gameObject);
        //    }
        //}
        TriggerControl(other, true, 1, 3, false);
    }
    void TriggerControl(Collider other, bool empty, int option, int layer, bool contain)
    {
        if (!other.gameObject.CompareTag("Untagged"))
        {
            Layer(other, option);
            isEmpty = empty;
            gameObject.layer = layer;
            if (SpawnSystem.Instance.spawnPoints.Contains(gameObject) == contain)
            {
                List(option);
            }
        }
    }
    void List(int option)
    {
        switch (option)
        {
            case 1 :
                SpawnSystem.Instance.spawnPoints.Add(gameObject);
                break;
            case 2 :
                SpawnSystem.Instance.spawnPoints.Remove(gameObject);
                break;
            default:
                break;
        }
    }
    void Layer(Collider other, int option)
    {
        switch (option)
        {
            case 1:
                break;
            case 2:
                other.gameObject.layer = other.gameObject.GetComponent<PlayerStateManager>().myLayer;
                break;
            default:
                break;
        }
    }
}
