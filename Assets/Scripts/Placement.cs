using System;
using System.Collections.Generic;
using UnityEngine;

public class Placement : MonoBehaviour
{
    public static Placement instance;
    public LayerMask checkLayers;
    public LayerMask layerMask;
    //public LayerMask objLayer;

    Transform nearObject;
    public Vector3 mousePos;

    public bool isClick = false;
    public GameObject objMove;

    public float checkRadius;
    float posY = 0.25f;
    float posX, posZ;
    float firstPosX, firstPosZ;
    float lastPosX, lastPosZ;
    public int myLayer;
    //int tagCount;
    private void Awake()
    {
        instance = this;
        myLayer = gameObject.layer;
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
            //objMove.gameObject.layer = 7;
            isClick = false;
            lastPosX = nearObject.position.x;
            lastPosZ = nearObject.position.z;
            if (!objMove.gameObject.GetComponent<ObjectCrash>().isCrash)
            {
                Debug.Log("d");
                objMove.transform.position = new Vector3(lastPosX, 0.225f, lastPosZ);
            }
            else
            {
                if (!objMove.gameObject.GetComponent<ObjectCrash>().isMerge)
                {
                    Debug.Log("i");
                    objMove.transform.position = new Vector3(posX, 0.225f, posZ);
                }
                if (objMove.gameObject.GetComponent<ObjectCrash>().isMerge)
                {
                    Debug.Log("F");
                    for (int i = 0; i < SpawnSystem.instance.starObj.Count - 1; i++)
                    {
                        if (objMove.gameObject.tag == SpawnSystem.instance.starObj[i].tag && objMove.layer == 10)
                        {
                            lastPosX = objMove.GetComponent<ObjectCrash>().near.transform.position.x;
                            lastPosZ = objMove.GetComponent<ObjectCrash>().near.transform.position.z;
                            Instantiate(SpawnSystem.instance.starObj[i + 1], new Vector3(lastPosX, 0.225f, lastPosZ), transform.rotation);
                            Destroy(objMove.gameObject.GetComponent<Placement>().objMove.gameObject);
                            Destroy(objMove.gameObject.GetComponent<ObjectCrash>().near);
                        }
                    }
                    for (int i = 0; i < SpawnSystem.instance.plusObj.Count - 1; i++)
                    {
                        if (objMove.gameObject.tag == SpawnSystem.instance.plusObj[i].tag && objMove.layer == 11)
                        {
                            lastPosX = objMove.GetComponent<ObjectCrash>().near.transform.position.x;
                            lastPosZ = objMove.GetComponent<ObjectCrash>().near.transform.position.z;
                            Instantiate(SpawnSystem.instance.plusObj[i + 1], new Vector3(lastPosX, 0.225f, lastPosZ), transform.rotation);
                            Destroy(objMove.gameObject.GetComponent<Placement>().objMove.gameObject);
                            Destroy(objMove.gameObject.GetComponent<ObjectCrash>().near);
                        }
                    }
                    for (int i = 0; i < SpawnSystem.instance.minusObj.Count - 1; i++)
                    {
                        if (objMove.gameObject.tag == SpawnSystem.instance.minusObj[i].tag && objMove.layer == 12)
                        {
                            lastPosX = objMove.GetComponent<ObjectCrash>().near.transform.position.x;
                            lastPosZ = objMove.GetComponent<ObjectCrash>().near.transform.position.z;
                            Instantiate(SpawnSystem.instance.minusObj[i + 1], new Vector3(lastPosX, 0.225f, lastPosZ), transform.rotation);
                            Destroy(objMove.gameObject.GetComponent<Placement>().objMove.gameObject);
                            Destroy(objMove.gameObject.GetComponent<ObjectCrash>().near);
                        }
                    }
                }
            }
        }
    }
    private void OnMouseDown()
    {
        if (objMove.tag == "4")
        {
            gameObject.GetComponent<Placement>().enabled = false;
        }
        objMove.gameObject.layer = myLayer + 3;
        isClick = true;
    }
}
