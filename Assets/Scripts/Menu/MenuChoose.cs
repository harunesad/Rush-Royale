using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
        menus.GetComponent<RectTransform>().localPosition = new Vector3(posZ, 0, 0);
    }
    //public void CardsMenu(float posZ)
    //{
    //    menus.GetComponent<RectTransform>().position = new Vector3(posZ, 0, 0);
    //}
}
