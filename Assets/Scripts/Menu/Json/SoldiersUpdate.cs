using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoldiersUpdate : MonoBehaviour
{
    public SaveObject so;
    public PlayerSoldiers soldiers;
    GameObject variableForPrefab;
    void Start()
    {
        so = SaveManager.Load();
        ListUpdate(soldiers.starObj, 0);
        ListUpdate(soldiers.plusObj, 1);
        ListUpdate(soldiers.minusObj, 2);
        ListUpdate(soldiers.divideObj, 3);
        for (int i = 0; i < 4; i++)
        {
            Debug.Log(so.soldiersName[i]);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void ListUpdate(List<GameObject> soldier, int element)
    {
        for (int i = 0; i < soldier.Count; i++)
        {
            string soldierName = so.soldiersName[element] + (i + 1);
            string path = so.soldiersName[element] + "/" + soldierName;
            variableForPrefab = Resources.Load(path) as GameObject;
            soldier[i] = variableForPrefab;
        }
    }
}
