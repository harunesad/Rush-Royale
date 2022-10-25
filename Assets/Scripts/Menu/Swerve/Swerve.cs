using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Swerve : MonoBehaviour
{
    SwerveControl swerveControl;
    public GameObject menus;
    public List<float> menusPos;
    private void Awake()
    {
        swerveControl = GetComponent<SwerveControl>();
    }
    private void Update()
    {
        Move(0, 1, 0);
        Move(1, 2, 0);
        Move(2, 2, 1);
    }
    public void Move(int index, int plus, int minus)
    {
        RectTransform transform = menus.GetComponent<RectTransform>();

        if (swerveControl.MoveFactorX < -5 && menusPos[index] == transform.localPosition.x)
        {
            transform.DOLocalMove(new Vector3(menusPos[minus], 0, 0), 0.4f);
        }
        else if(swerveControl.MoveFactorX > 5 && menusPos[index] == transform.localPosition.x)
        {
            transform.DOLocalMove(new Vector3(menusPos[plus], 0, 0), 0.4f);
        }
    }
}
