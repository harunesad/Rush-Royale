using System;
using System.Collections.Generic;
using UnityEngine;

public class Placement : MonoBehaviour
{
    public static Placement instance;
    public LayerMask checkLayers;
    public LayerMask layerMask;
    public LayerMask layerMaskBase;

    [SerializeField] Transform nearObject;
    public Vector3 mousePos;

    public bool isClick = false;
    public GameObject objMove;

    public float checkRadius;
    float posY = 0.35f;
    float posX, posZ;
    float firstPosX, firstPosZ;
    float lastPosX, lastPosZ;
    public int myLayer;
    Compare compare;

    [SerializeField] bool firstPos = false;
    private void Awake()
    {
        instance = this;
        myLayer = gameObject.layer;
        compare = GetComponent<Compare>();
    }
    void Update()
    {
        nearObject = compare.nearObj;
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
                objMove.transform.position = new Vector3(firstPosX, posY, firstPosZ);
                firstPos = true;
            }
            if (Physics.Raycast(ray, out hit, Mathf.Infinity, layerMaskBase))
            {
                firstPosX = hit.point.x;
                firstPosZ = hit.point.z;
                objMove.transform.position = new Vector3(firstPosX, posY, firstPosZ);
                firstPos = false;
            }
        }
        if (Input.GetMouseButtonUp(0))
        {
            isClick = false;
            if (!objMove.gameObject.GetComponent<ObjectCrash>().isCrash)
            {
                Debug.Log("d");
                if (!firstPos)
                {
                    lastPosX = nearObject.position.x;
                    lastPosZ = nearObject.position.z;
                    objMove.transform.position = new Vector3(firstPosX, 0.225f, firstPosZ);
                }
                else
                {
                    objMove.transform.position = new Vector3(posX, 0.225f, posZ);
                }
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
                    SpawnNextLevel(SpawnSystem.Instance.starObj, 11);
                    SpawnNextLevel(SpawnSystem.Instance.plusObj, 12);
                    SpawnNextLevel(SpawnSystem.Instance.minusObj, 13);
                    SpawnNextLevel(SpawnSystem.Instance.divideObj, 14);
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
        objMove.gameObject.layer = myLayer + 4;
        isClick = true;
    }
    void SpawnNextLevel(List<GameObject> obj, int layerCount)
    {
        for (int i = 0; i < obj.Count - 1; i++)
        {
            if (objMove.gameObject.tag == obj[i].tag && objMove.layer == layerCount)
            {
                lastPosX = objMove.GetComponent<ObjectCrash>().crashObj.transform.position.x;
                lastPosZ = objMove.GetComponent<ObjectCrash>().crashObj.transform.position.z;
                var spawnObj = Instantiate(obj[i + 1], new Vector3(lastPosX, 0.225f, lastPosZ), transform.rotation);
                SpawnSystem.Instance.soldiers.Add(spawnObj);
                SpawnSystem.Instance.soldiers.Remove(objMove.gameObject.GetComponent<ObjectCrash>().crashObj);
                SpawnSystem.Instance.soldiers.Remove(objMove.gameObject.GetComponent<Placement>().objMove.gameObject);
                Destroy(objMove.gameObject.GetComponent<Placement>().objMove.gameObject);
                Destroy(objMove.gameObject.GetComponent<ObjectCrash>().crashObj);
            }
        }
    }
}
