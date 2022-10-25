using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
public class PanelState : MonoBehaviour
{
    public void ChestPanelClose(GameObject panel)
    {
        CardsInfo.cards.panelHolder.GetComponent<PanelSwipe>().enabled = true;
        Debug.Log("sdaas");
        CardsPanelClick();
        panel.SetActive(false);
    }
    public void CardsPanelClick()
    {
        if (ButtonSelect.instance.useButton != null && ButtonSelect.instance.infoButton != null)
        {
            ButtonSelect.instance.progressBar.gameObject.SetActive(true);
            ButtonSelect.instance.progressText.gameObject.SetActive(true);
            ButtonSelect.instance.useButton.SetActive(false);
            ButtonSelect.instance.infoButton.SetActive(false);
            ButtonSelect.instance.upgradeButton.SetActive(false);
            ButtonClick.instance.newImage = null;
        }
    }
    public void ChestPanelOpen(GameObject panel)
    {
        panel.SetActive(!panel.activeSelf);
    }
    public void ChestCardPanelClose(GameObject panel)
    {
        panel.SetActive(!panel.activeSelf);
    }
    void Update()
    {
        
    }
}
