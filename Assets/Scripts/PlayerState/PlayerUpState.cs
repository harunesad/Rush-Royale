using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerUpState : PlayerBaseState
{
    float lastPosX, lastPosZ;
    private GameObject variableForPrefab;
    string soldierName;

    //char[] newName;
    public override void EnterState(PlayerStateManager player)
    {
        if (!player.objMove.gameObject.GetComponent<PlayerStateManager>().isMerge)
        {
            player.objMove.transform.position = new Vector3(player.posX, 0.225f, player.posZ);
        }
        else
        {
            SpawnNextLevel(player);
            //SpawnNextLevel(player.soldiers.plusObj, 12, player);
            //SpawnNextLevel(player.soldiers.minusObj, 13, player);
            //SpawnNextLevel(player.soldiers.divideObj, 14, player);
        }
        player.SwitchState(player.DownState);
    }
    public override void UpdateState(PlayerStateManager player)
    {

    }
    void SpawnNextLevel(PlayerStateManager player)
    {
        //for (int i = 0; i < obj.Count - 1; i++)
        //{
        //    if (player.objMove.gameObject.tag == obj[i].tag)
        //    {
        //        var name = player.objMove.name.ToCharArray();
        //        int arrayCount = name.Length - 8;
        //        char[] newName = new char[arrayCount];
        //        string level = System.Convert.ToString(name[arrayCount]);
        //        int levelNumber = int.Parse(level);
        //        for (int j = 0; j < arrayCount; j++)
        //        {
        //            newName[j] = name[j];
        //            Debug.Log(newName[j]);
        //        }
        //        for (int k = 0; k < arrayCount; k++)
        //        {
        //            soldierName = soldierName + newName[k];
        //        }
        //        levelNumber++;
        //        string spawnName = soldierName + levelNumber.ToString();
        //        string path = soldierName + "/" + spawnName;
        //        variableForPrefab = Resources.Load(path) as GameObject;
        //        lastPosX = player.objMove.GetComponent<PlayerStateManager>().crashObj.transform.position.x;
        //        lastPosZ = player.objMove.GetComponent<PlayerStateManager>().crashObj.transform.position.z;
        //        var spawnObj = Object.Instantiate(variableForPrefab, new Vector3(lastPosX, 0.225f, lastPosZ), player.transform.rotation);
        //        SpawnSystem.Instance.soldiers.Add(spawnObj);
        //        SpawnSystem.Instance.soldiers.Remove(player.objMove.gameObject.GetComponent<PlayerStateManager>().crashObj);
        //        SpawnSystem.Instance.soldiers.Remove(player.objMove.gameObject.GetComponent<PlayerStateManager>().objMove.gameObject);
        //        Object.Destroy(player.objMove.gameObject.GetComponent<PlayerStateManager>().objMove.gameObject);
        //        Object.Destroy(player.objMove.gameObject.GetComponent<PlayerStateManager>().crashObj);
        //        soldierName = "";
        //    }
        //}
        var name = player.objMove.name.ToCharArray();
        int arrayCount = name.Length - 8;
        char[] newName = new char[arrayCount];
        string level = System.Convert.ToString(name[arrayCount]);
        int levelNumber = int.Parse(level);

        for (int j = 0; j < arrayCount; j++)
        {
            newName[j] = name[j];
            Debug.Log(newName[j]);
        }

        for (int k = 0; k < arrayCount; k++)
        {
            soldierName = soldierName + newName[k];
        }

        levelNumber++;
        string spawnName = soldierName + levelNumber.ToString();
        string path = soldierName + "/" + spawnName;
        variableForPrefab = Resources.Load(path) as GameObject;

        lastPosX = player.objMove.GetComponent<PlayerStateManager>().crashObj.transform.position.x;
        lastPosZ = player.objMove.GetComponent<PlayerStateManager>().crashObj.transform.position.z;
        var spawnObj = Object.Instantiate(variableForPrefab, new Vector3(lastPosX, 0.225f, lastPosZ), player.transform.rotation);
        SpawnSystem.Instance.soldiers.Add(spawnObj);

        SpawnSystem.Instance.soldiers.Remove(player.objMove.gameObject.GetComponent<PlayerStateManager>().crashObj);
        SpawnSystem.Instance.soldiers.Remove(player.objMove.gameObject.GetComponent<PlayerStateManager>().objMove.gameObject);
        Object.Destroy(player.objMove.gameObject.GetComponent<PlayerStateManager>().objMove.gameObject);
        Object.Destroy(player.objMove.gameObject.GetComponent<PlayerStateManager>().crashObj);

        soldierName = "";
    }
    public string soldierList(string upgradeName, int level)
    {
        upgradeName = upgradeName + "/" + level;
        string path = upgradeName + "/" + level;
        GameObject upgradeObj = variableForPrefab = Resources.Load(path) as GameObject;
        return soldierName;
    }
    public override void OnTriggerEnter(PlayerStateManager player, Collider other)
    {
        
    }
    public override void OnTriggerStay(PlayerStateManager player, Collider other)
    {

    }
    public override void OnTriggerExit(PlayerStateManager player, Collider other)
    {
        
    }

    public override void OnMouseDown(PlayerStateManager player)
    {

    }

    public override void OnMouseDrag(PlayerStateManager player)
    {

    }

    public override void OnMouseUp(PlayerStateManager player)
    {

    }
}
