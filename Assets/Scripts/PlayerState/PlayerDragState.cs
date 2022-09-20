using System;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDragState : PlayerBaseState
{
    float posY = 0.35f;
    public override void EnterState(PlayerStateManager player)
    {
        //layerMaskBase = 15;
    }
    public override void UpdateState(PlayerStateManager player)
    {
        if (Input.GetMouseButton(0))
        {
            Collider[] colliders = Physics.OverlapSphere(player.transform.position, 10, player.checkLayers);
            Array.Sort(colliders, new DistanceCompare(player.transform));
            foreach (var item in colliders)
            {
                Debug.Log(item.transform.gameObject.name);
                player.nearObj = item.transform.gameObject;
                break;
            }

            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out hit, Mathf.Infinity, player.layerMaskBase))
            {
                player.objMove.transform.position = new Vector3(hit.point.x, posY, hit.point.z);
                player.firstPos = true;
            }
            if (Physics.Raycast(ray, out hit, Mathf.Infinity, player.layerMask))
            {
                player.objMove.transform.position = new Vector3(hit.point.x, posY, hit.point.z);
                player.firstPos = false;
            }
        }
        if (Input.GetMouseButtonUp(0))
        {
            player.SwitchState(player.UpState);
        }
    }
    public override void OnTriggerEnter(PlayerStateManager player, Collider other)
    {
        if ( !other.CompareTag("Untagged"))
        {
            player.others.Add(other.gameObject);
        }
    }
    public override void OnTriggerStay(PlayerStateManager player, Collider other)
    {
        for (int i = 0; i < player.others.Count; i++)
        {
            if (player.others[i] == null)
            {
                player.others.RemoveAt(i);
            }
            if (player.gameObject.tag == player.others[i].tag && player.others[i].transform.position == player.nearObj.transform.position)
            {
                player.isMerge = true;
                player.crashObj = player.others[i];
            }
        }
    }
    public override void OnTriggerExit(PlayerStateManager player, Collider other)
    {
        if (player.others.Count > 0)
        {
            player.others.Remove(other.gameObject);
        }
        if (player.crashObj == other.gameObject)
        {
            player.isMerge = false;
        }
    }
}
