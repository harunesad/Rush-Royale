using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class ButtonSetActive : MonoBehaviour
{
    public static ButtonSetActive instance;
    private void Awake()
    {
        instance = this;
    }

    public void ClickImage(GameObject pointObj)
    {
        StartState(ButtonSelect.instance.useButton, ButtonSelect.instance.infoButton, false);
        StartState(ButtonSelect.instance.progressBar, ButtonSelect.instance.progressText, true);
        if (ButtonSelect.instance.upgradeButton != null)
        {
            ButtonSelect.instance.upgradeButton.SetActive(false);
        }
        ButtonSelect.instance.useButton = pointObj.transform.GetChild(0).gameObject;
        ButtonSelect.instance.infoButton = pointObj.transform.GetChild(1).gameObject;
        ButtonSelect.instance.progressBar = pointObj.transform.GetChild(2).gameObject;
        ButtonSelect.instance.progressText = pointObj.transform.GetChild(3).gameObject;
        ButtonSelect.instance.upgradeButton = pointObj.transform.GetChild(4).gameObject;

        pointObj.transform.GetChild(0).gameObject.SetActive(true);
        pointObj.transform.GetChild(2).gameObject.SetActive(false);
        pointObj.transform.GetChild(3).gameObject.SetActive(false);
        if (ButtonSelect.instance.progressBar.GetComponent<Image>().fillAmount < 1)
        {
            pointObj.transform.GetChild(1).gameObject.SetActive(true);
        }
        else
        {
            pointObj.transform.GetChild(4).gameObject.SetActive(true);
        }
        Debug.Log(gameObject.name);
    }
    void StartState(GameObject firstObj, GameObject seconObj, bool state)
    {
        if (firstObj != null && seconObj != null)
        {
            firstObj.SetActive(state);
            seconObj.SetActive(state);
        }
    }
    public void ButtonState()
    {
        ButtonSelect.instance.useButton.SetActive(false);
        ButtonSelect.instance.infoButton.SetActive(false);
        ButtonSelect.instance.upgradeButton.SetActive(false);
    }
    public void ProgressState()
    {
        ButtonSelect.instance.progressBar.SetActive(true);
        ButtonSelect.instance.progressText.SetActive(true);
    }
    void Start()
    {
        
    }
    void Update()
    {
        
    }
}
