using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridManager : MonoBehaviour
{
    [Header("Plane")]
    [SerializeField] float planeXStart;
    [SerializeField] float planeZStart;
    [SerializeField] int planeColumnLength, planeRowLength;
    [SerializeField] float planeSpace;
    [Space(10)]
    [Header("VerticalEdge")]
    [SerializeField] float verticalEdgeZStart;
    [SerializeField] int EdgeColumnLength, EdgeRowLength;
    [SerializeField] float verticalEdgeSpace;
    float verticalEdgeXStart = 0;
    [Space(10)]
    [Header("HorizontalEdge")]
    [SerializeField] float horizontalEdgeXStart;
    [SerializeField] float horizontalEdgeZStart;
    [SerializeField] float horizontalEdgeSpace;
    [Space(10)]
    [Header("Prefab")]
    [SerializeField] GameObject plane;
    [SerializeField] GameObject edgeVertical;
    [SerializeField] GameObject horizontalEdge;
    void Start()
    {
        for (int i = 0; i < planeColumnLength * planeRowLength; i++)
        {
            var ground = Instantiate(plane, new Vector3(planeXStart + (planeSpace * (i % planeColumnLength)),0 , planeZStart + (planeSpace * (i / planeRowLength))), Quaternion.identity);
            ground.layer = 3;
            ground.transform.parent = gameObject.transform;
        }

        for (int i = 0; i < EdgeColumnLength * EdgeRowLength; i++)
        {
            var side = Instantiate(edgeVertical, new Vector3(verticalEdgeXStart, 0.001f, verticalEdgeZStart + (verticalEdgeSpace * (i / EdgeRowLength))), Quaternion.identity);
            //side.layer = 3;
            side.transform.parent = gameObject.transform;
        }

        for (int i = 0; i < EdgeColumnLength * EdgeRowLength; i++)
        {
            var side = Instantiate(horizontalEdge, new Vector3(horizontalEdgeXStart + ((horizontalEdgeSpace) * (i / EdgeRowLength)), 0.001f, horizontalEdgeZStart), horizontalEdge.transform.rotation);
            //side.layer = 3;
            side.transform.parent = gameObject.transform;
        }
    }
}
