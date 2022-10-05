using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
public class ChestPanelClose : MonoBehaviour, IPointerDownHandler
{
    public void OnPointerDown(PointerEventData eventData)
    {
        ButtonClick.instance.panelHolder.GetComponent<PanelSwipe>().enabled = true;
        Debug.Log("sdaas");
        gameObject.transform.parent.gameObject.SetActive(false);
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }
    public void ChestPanel(GameObject panel)
    {
        ButtonClick.instance.panelHolder.GetComponent<PanelSwipe>().enabled = true;
        Debug.Log("sdaas");
        panel.SetActive(false);
    }
    public void ButtonFalse()
    {
        if (ButtonSelect.instance.useButton != null && ButtonSelect.instance.infoButton != null)
        {
            GameObject parent = ButtonSelect.instance.useButton.transform.parent.gameObject;
            parent.transform.GetChild(2).gameObject.SetActive(true);
            parent.transform.GetChild(3).gameObject.SetActive(true);
            ButtonSelect.instance.useButton.SetActive(false);
            ButtonSelect.instance.infoButton.SetActive(false);
        }
    }
    public void ChestPanelOpen(GameObject panel)
    {
        panel.SetActive(true);
    }
    public void PanelClose(GameObject panel)
    {
        panel.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
