using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class ButtonClick : MonoBehaviour
{
    public static ButtonClick instance;
    public GameObject newImage;
    GameObject playButton;
    public SaveObject so;
    private void Awake()
    {
        instance = this;
        playButton = GameObject.Find("PlayButton");
        playButton.GetComponent<Button>().onClick.AddListener(PlayButton);
    }
    void Update()
    {

    }
    void PlayButton()
    {
        DeckControl();
    }
    public void UseButton(Button clickButton)
    {
        var parent = clickButton.transform.parent;
        newImage = parent.gameObject;
    }
    public void SaveDeck()
    {       
        for (int i = 0; i < DeckChange.instance.DeckList.Count; i++)
        {
            so.soldiersName[i] = DeckChange.instance.DeckList[i].name;
        }
        SaveManager.Save(so);
    }
    void DeckControl()
    {
        for (int i = 0; i < DeckChange.instance.DeckList.Count; i++)
        {
            if (DeckChange.instance.DeckList[i].GetComponent<Image>().sprite == null)
            {
                Debug.Log("a");
                return;
            }
            SceneManager.LoadScene(2);
        }
    }
}
