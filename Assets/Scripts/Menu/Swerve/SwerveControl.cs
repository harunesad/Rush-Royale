using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwerveControl : MonoBehaviour
{
    float lastFrameFingerPositionX;
    public float moveFactorX;
    public float MoveFactorX => moveFactorX;
    private void Update()
    {
        System();
    }
    public void System()
    {
        if (Input.GetMouseButtonDown(0))
        {
            lastFrameFingerPositionX = Input.mousePosition.x;
        }
        else if (Input.GetMouseButton(0))
        {
            moveFactorX = Input.mousePosition.x - lastFrameFingerPositionX;
            lastFrameFingerPositionX = Input.mousePosition.x;
        }
        else if (Input.GetMouseButtonUp(0))
        {
            moveFactorX = 0f;
        }
    }
}
