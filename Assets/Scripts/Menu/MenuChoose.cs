using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class MenuChoose : MonoBehaviour
{
    public GameObject menus;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void MenuPass(float posZ)
    {
        menus.GetComponent<RectTransform>().DOLocalMove(new Vector3(posZ, 0, 0), 0.4f);
    }
    //public void CardsMenu(float posZ)
    //{
    //    menus.GetComponent<RectTransform>().position = new Vector3(posZ, 0, 0);
    //}
}
