using System;
using System.Collections.Generic;
using UnityEngine;

public class Placement : MonoBehaviour
{
    public static Placement instance;
    [SerializeField] LayerMask checkLayers;
    [SerializeField] LayerMask layerMask;

    Transform nearObject;
    public Vector3 mousePos;

    public bool isClick = false;
    public GameObject objMove;

    [SerializeField] float checkRadius;
    float posY = 0.25f;
    float posX, posZ;
    float firstPosX, firstPosZ;
    float lastPosX, lastPosZ;
    private void Awake()
    {
        instance = this;
    }
    void Update()
    {
        Collider[] colliders = Physics.OverlapSphere(transform.position, checkRadius, checkLayers);
        Array.Sort(colliders, new DistanceCompare(transform));
        foreach (var item in colliders)
        {
            nearObject = item.transform;
            break;
        }
        if (Input.GetMouseButtonDown(0))
        {
            posX = transform.position.x;
            posZ = transform.position.z;
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
                firstPosX = Math.Clamp(firstPosX, -1.025f, 1.025f);
                firstPosZ = Math.Clamp(firstPosZ, -3, -1.975f);

                objMove.transform.position = new Vector3(firstPosX, posY, firstPosZ);
            }
        }
        if (Input.GetMouseButtonUp(0))
        {
            isClick = false;
            if (nearObject.GetComponent<Trigger>().isEmpty)
            {
                lastPosX = nearObject.position.x;
                lastPosZ = nearObject.position.z;

                objMove.transform.position = new Vector3(lastPosX, 0.225f, lastPosZ);
            }
            else
            {
                objMove.transform.position = new Vector3(posX, 0.225f, posZ);
            }
        }
    }
    private void OnMouseDown()
    {
        isClick = true;
    }
}
