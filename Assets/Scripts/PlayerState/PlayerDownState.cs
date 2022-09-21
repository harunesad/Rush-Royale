using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDownState : PlayerBaseState
{
    public override void EnterState(PlayerStateManager player)
    {

    }
    public override void UpdateState(PlayerStateManager player)
    {
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out hit, Mathf.Infinity))
            {
                if (hit.transform == player.transform)
                {
                    player.posX = player.transform.position.x;
                    player.posZ = player.transform.position.z;
                    if (player.objMove.tag == "4")
                    {
                        player.gameObject.GetComponent<PlayerStateManager>().enabled = false;
                    }
                    player.objMove.gameObject.layer = player.myLayer + 4;
                    player.SwitchState(player.DragState);
                }
            }
        }
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
}
