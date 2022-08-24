using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnSystem : MonoBehaviour
{
    public static SpawnSystem instance;
    public List<GameObject> spawnPoints;
    public List<GameObject> starObj;
    public List<GameObject> plusObj;
    public List<GameObject> minusObj;
    [SerializeField] GameObject spawnStar;
    [SerializeField] GameObject spawnPlus;
    [SerializeField] GameObject spawnMinus;
    Vector3 pos;
    //int randomIndex;
    private void Awake()
    {
        instance = this;
    }
    private void Update()
    {

    }
    public void SpawnStar()
    {
        int randomIndex = Random.Range(0, spawnPoints.Count);
        if (spawnPoints.Count > 0)
        {
            for (int i = randomIndex; i < randomIndex + 1; i++)
            {
                pos = spawnPoints[i].transform.position;
            }
        }
        if (spawnPoints.Count > 0)
        {
            Instantiate(spawnStar, pos + Vector3.up * 0.225f, Quaternion.identity);
        }
    }
    public void SpawnPlus()
    {
        int randomIndex = Random.Range(0, spawnPoints.Count);
        if (spawnPoints.Count > 0)
        {
            for (int i = randomIndex; i < randomIndex + 1; i++)
            {
                pos = spawnPoints[i].transform.position;
            }
        }
        if (spawnPoints.Count > 0)
        {
            Instantiate(spawnPlus, pos + Vector3.up * 0.225f, Quaternion.identity);
        }
    }
    public void SpawnMinus()
    {
        int randomIndex = Random.Range(0, spawnPoints.Count);
        if (spawnPoints.Count > 0)
        {
            for (int i = randomIndex; i < randomIndex + 1; i++)
            {
                pos = spawnPoints[i].transform.position;
            }
        }
        if (spawnPoints.Count > 0)
        {
            Instantiate(spawnMinus, pos + Vector3.up * 0.225f, Quaternion.identity);
        }
    }
}
