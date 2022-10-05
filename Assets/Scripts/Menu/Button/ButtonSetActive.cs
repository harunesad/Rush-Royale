using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class ButtonSetActive : MonoBehaviour, IPointerDownHandler
{
    public void OnPointerDown(PointerEventData eventData)
    {
        if (ButtonSelect.instance.useButton != null && ButtonSelect.instance.infoButton != null)
        {
            ButtonSelect.instance.useButton.SetActive(false);
            ButtonSelect.instance.infoButton.SetActive(false);
        }
        if (ButtonSelect.instance.progressBar != null && ButtonSelect.instance.progressText != null)
        {
            ButtonSelect.instance.progressBar.SetActive(true);
            ButtonSelect.instance.progressText.SetActive(true);
        }
        ButtonSelect.instance.progressBar = gameObject.transform.GetChild(2).gameObject;
        ButtonSelect.instance.progressText = gameObject.transform.GetChild(3).gameObject;
        gameObject.transform.GetChild(2).gameObject.SetActive(false);
        gameObject.transform.GetChild(3).gameObject.SetActive(false);

        ButtonSelect.instance.useButton = gameObject.transform.GetChild(0).gameObject;
        ButtonSelect.instance.infoButton = gameObject.transform.GetChild(1).gameObject;
        gameObject.transform.GetChild(0).gameObject.SetActive(true);
        gameObject.transform.GetChild(1).gameObject.SetActive(true);
    }

    void Start()
    {
        
    }
    void Update()
    {
        
    }
}
