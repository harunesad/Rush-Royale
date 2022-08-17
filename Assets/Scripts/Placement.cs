using System;
using System.Collections.Generic;
using UnityEngine;

public class Placement : MonoBehaviour
{
    [SerializeField] LayerMask checkLayers;
    [SerializeField] LayerMask layerMask;

    Transform nearObject;
    public Vector3 mousePos;

    public bool isClick = false;
    public GameObject objMove;

    [SerializeField] float checkRadius;
    float posY = 0.5f;
    float firstPosX, firstPosZ;
    float lastPosX, lastPosZ;
    void Update()
    {
        Collider[] colliders = Physics.OverlapSphere(transform.position, checkRadius, checkLayers);
        Array.Sort(colliders, new DistanceCompare(transform));
        foreach (var item in colliders)
        {
            nearObject = item.transform;
            break;
        }

        if (Input.GetMouseButton(0) && isClick)
        {
            mousePos = Input.mousePosition;
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(mousePos);

            if (Physics.Raycast(ray, out hit, Mathf.Infinity, layerMask))
            {
                firstPosX = hit.point.x;
                firstPosZ = hit.point.z;
                firstPosX = Math.Clamp(firstPosX, -2.565f, 2.565f);
                firstPosZ = Math.Clamp(firstPosZ, -3, 2.125f);

                objMove.transform.position = new Vector3(firstPosX, posY, firstPosZ);
            }
        }
        if (Input.GetMouseButtonUp(0) )
        {
            lastPosX = nearObject.position.x;
            lastPosZ = nearObject.position.z;  

            objMove.transform.position = new Vector3(lastPosX, posY, lastPosZ);
            isClick = false;
        }
    }
    private void OnMouseDown()
    {
        isClick = true;
    }
}
