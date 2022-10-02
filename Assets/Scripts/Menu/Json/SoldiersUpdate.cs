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
        ListUpdate(soldiers.firstObj, 0);
        ListUpdate(soldiers.secondObj, 1);
        ListUpdate(soldiers.thirdObj, 2);
        ListUpdate(soldiers.fourthObj, 3);

        TextUpdate();
        FirstSpawnUpdate();
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
    void TextUpdate()
    {
        for (int i = 0; i < so.soldiersName.Count; i++)
        {
            UpgradeSystem.Instance.upgradeText[i].text = so.soldiersName[i];
        }
    }
    void FirstSpawnUpdate()
    {
        SpawnSystem.Instance.spawnObj[0] = soldiers.firstObj[0];
        SpawnSystem.Instance.spawnObj[1] = soldiers.secondObj[0];
        SpawnSystem.Instance.spawnObj[2] = soldiers.thirdObj[0];
        SpawnSystem.Instance.spawnObj[3] = soldiers.fourthObj[0];
    }
}
