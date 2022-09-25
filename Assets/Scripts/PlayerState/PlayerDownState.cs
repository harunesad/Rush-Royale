using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDownState : PlayerBaseState
{
    bool result;

    public override void EnterState(PlayerStateManager player)
    {

    }
    public override void UpdateState(PlayerStateManager player)
    {

    }
    public override void OnTriggerEnter(PlayerStateManager player, Collider other)
    {
        GameObject go = other.gameObject;
        if (go.CompareTag("Ground"))
        {
            player.groundObj = go;
        }
    }
    public override void OnTriggerStay(PlayerStateManager player, Collider other)
    {

    }
    public override void OnTriggerExit(PlayerStateManager player, Collider other)
    {
        
    }

    public override void OnMouseDown(PlayerStateManager player)
    {
        if (player.objMove.tag == "4" || Time.timeScale == 0)
        {
            player.enabled = false;
            return;
        }
        player.posX = player.transform.position.x;
        player.posZ = player.transform.position.z;

        player.objMove.gameObject.layer = player.myLayer + 4;
        player.SwitchState(player.DragState);
    }

    public override void OnMouseDrag(PlayerStateManager player)
    {

    }

    public override void OnMouseUp(PlayerStateManager player)
    {

    }
}
