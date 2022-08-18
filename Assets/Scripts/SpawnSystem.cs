using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnSystem : MonoBehaviour
{
    public static SpawnSystem instance;
    public List<GameObject> spawnPoints;
    public List<GameObject> removePoints;
    public List<GameObject> levelObj;
    public List<bool> isEmpty;
    [SerializeField] GameObject spawnObj;
    Vector3 pos;
    int randomIndex;
    GameObject a;
    private void Awake()
    {
        instance = this;
    }
    private void Update()
    {
        int count = GameObject.FindGameObjectsWithTag("1").Length;
        Debug.Log(count);
        if (count < 1 && a != null)
        {
            levelObj.Add(a);
        }
    }
    public void SpawnObject()
    {
        randomIndex = Random.Range(0, spawnPoints.Count);
        if (spawnPoints.Count > 0)
        {
            for (int i = randomIndex; i < randomIndex + 1; i++)
            {
                //removePoints.Add(spawnPoints[i]);

                pos = spawnPoints[i].transform.position;
                //isEmpty[i] = false;
                //spawnPoints.RemoveAt(i);
            }
        }

        //for (int i = 0; i < spawnPoints.Count; i++)
        //{
        //    if (removePoints.Count > 0 && removePoints[i].GetComponent<Trigger>().isEmpty == false)
        //    {
        //        spawnPoints.Add(removePoints[i]);
        //    }
        //}
        var obj = Instantiate(spawnObj, pos + Vector3.up * 0.225f, Quaternion.identity);
        a = obj;
        //for (int i = 0; i < levelObj.Count; i++)
        //{
        //    if (obj.name != levelObj[i].name)
        //    {
        //        levelObj.Add(obj);
        //    }
        //    else
        //    {
        //        return;
        //    }
        //}
        //if (!levelObj.Contains(obj.gameObject))
        //{
        //    levelObj.Add(obj.gameObject);
        //}
    }
}
