using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerUpState : PlayerBaseState
{
    float lastPosX, lastPosZ;
    Compare compare;
    Transform nearPos;
    public override void EnterState(PlayerStateManager player)
    {
        compare = player.GetComponent<Compare>();
        if (!player.objMove.gameObject.GetComponent<PlayerStateManager>().isMerge)
        {
            Debug.Log("d");
            if (!player.firstPos)
            {
                nearPos = compare.nearPos;
                if (nearPos.GetComponent<Trigger>().isEmpty)
                {
                    lastPosX = nearPos.position.x;
                    lastPosZ = nearPos.position.z;
                    player.objMove.transform.position = new Vector3(lastPosX, 0.225f, lastPosZ);
                }
                else
                {
                    player.objMove.transform.position = new Vector3(player.posX, 0.225f, player.posZ);
                }
            }
            else
            {
                player.objMove.transform.position = new Vector3(player.posX, 0.225f, player.posZ);
            }
        }
        else
        {
            //if (!player.objMove.gameObject.GetComponent<PlayerStateManager>().isMerge)
            //{
            //    Debug.Log("i");
            //    player.objMove.transform.position = new Vector3(player.posX, 0.225f, player.posZ);
            //}
            //if (player.objMove.gameObject.GetComponent<PlayerStateManager>().isMerge)
            //{
            //    Debug.Log("F");
            //    SpawnNextLevel(SpawnSystem.Instance.starObj, 11, player);
            //    SpawnNextLevel(SpawnSystem.Instance.plusObj, 12, player);
            //    SpawnNextLevel(SpawnSystem.Instance.minusObj, 13, player);
            //    SpawnNextLevel(SpawnSystem.Instance.divideObj, 14, player);
            //}
            SpawnNextLevel(SpawnSystem.Instance.starObj, 11, player);
            SpawnNextLevel(SpawnSystem.Instance.plusObj, 12, player);
            SpawnNextLevel(SpawnSystem.Instance.minusObj, 13, player);
            SpawnNextLevel(SpawnSystem.Instance.divideObj, 14, player);
        }
        player.SwitchState(player.DownState);
    }
    public override void UpdateState(PlayerStateManager player)
    {
        //nearObject = compare.nearObj;
    }
    void SpawnNextLevel(List<GameObject> obj, int layerCount, PlayerStateManager player)
    {
        for (int i = 0; i < obj.Count - 1; i++)
        {
            if (player.objMove.gameObject.tag == obj[i].tag && player.objMove.layer == layerCount)
            {
                lastPosX = player.objMove.GetComponent<PlayerStateManager>().crashObj.transform.position.x;
                lastPosZ = player.objMove.GetComponent<PlayerStateManager>().crashObj.transform.position.z;
                var spawnObj = Object.Instantiate(obj[i + 1], new Vector3(lastPosX, 0.225f, lastPosZ), player.transform.rotation);
                SpawnSystem.Instance.soldiers.Add(spawnObj);
                SpawnSystem.Instance.soldiers.Remove(player.objMove.gameObject.GetComponent<PlayerStateManager>().crashObj);
                SpawnSystem.Instance.soldiers.Remove(player.objMove.gameObject.GetComponent<PlayerStateManager>().objMove.gameObject);
                Object.Destroy(player.objMove.gameObject.GetComponent<PlayerStateManager>().objMove.gameObject);
                Object.Destroy(player.objMove.gameObject.GetComponent<PlayerStateManager>().crashObj);
            }
        }
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
}
