using System;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDragState : PlayerBaseState
{
    float posY = 0.35f;
    float posX;
    float posZ;
    Compare compare;
    Transform nearPos;
    public override void EnterState(PlayerStateManager player)
    {
        compare = GameObject.Find("Compare").GetComponent<Compare>();
        posX = player.posX;
        posZ = player.posZ;
        compare.soldier = player.transform;
        compare.layerObject.value = player.firstLayer;
    }
    public override void UpdateState(PlayerStateManager player)
    {

    }
    public override void OnTriggerEnter(PlayerStateManager player, Collider other)
    {

    }
    public override void OnTriggerStay(PlayerStateManager player, Collider other)
    {
        player.colObj = other.gameObject;

        if (player.gameObject.tag == player.colObj.tag && player.colObj.transform.position == player.nearObj.transform.position)
        {
            player.isMerge = true;
            player.crashObj = player.colObj;
        }
    }
    public override void OnTriggerExit(PlayerStateManager player, Collider other)
    {
        if (player.crashObj == other.gameObject)
        {
            player.isMerge = false;
        }
    }

    public override void OnMouseDown(PlayerStateManager player)
    {

    }

    public override void OnMouseDrag(PlayerStateManager player)
    {
        compare.CompareGround();
        compare.CompareObject();
        if (compare.nearObject != null)
        {
            player.nearObj = compare.nearObject.gameObject;
        }
        RaycastHit hit;
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(ray, out hit, Mathf.Infinity, player.layerMaskBase))
        {
            player.posX = posX;
            player.posZ = posZ;
            player.objMove.transform.position = new Vector3(hit.point.x, posY, hit.point.z);
        }
        if (Physics.Raycast(ray, out hit, Mathf.Infinity, player.layerMask))
        {
            nearPos = compare.nearGround;
            player.objMove.transform.position = new Vector3(hit.point.x, posY, hit.point.z);
            if (nearPos.GetComponent<Trigger>().isEmpty)
            {
                player.posX = nearPos.position.x;
                player.posZ = nearPos.position.z;
            }
        }
    }

    public override void OnMouseUp(PlayerStateManager player)
    {
        player.SwitchState(player.UpState);
    }
}
