using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ButtonClick : MonoBehaviour
{
    public static ButtonClick instance;
    public Button clickButton;
    public GameObject newImage;
    GameObject playButton;
    public SaveObject so;
    private void Awake()
    {
        instance = this;
        playButton = GameObject.Find("PlayButton");
        playButton.GetComponent<Button>().onClick.AddListener(PlayButton);
    }
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void PlayButton()
    {
        if (so.soldiersName.Count > 0)
        {
            so.soldiersName.Clear();
        }
        //Debug.Log(DeckChange.instance.DeckList[0].GetComponent<Image>().sprite);
        for (int i = 0; i < DeckChange.instance.DeckList.Count; i++)
        {
            if (DeckChange.instance.DeckList[i].GetComponent<Image>().sprite == null)
            {
                return;
            }
            so.soldiersName.Add(DeckChange.instance.DeckList[i].name);
            //so.soldiersName[i] = DeckChange.instance.DeckList[i].name;
        }
        SaveManager.Save(so);
        SceneManager.LoadScene(1);
    }
    public void UseButton(Button clickButton)
    {
        var parent = clickButton.transform.parent;
        newImage = parent.gameObject;
    }
}
