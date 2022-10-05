using System.Collections;
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
    [SerializeField] GameObject ýnfoPanel;
    [SerializeField] TextMeshProUGUI attackText;
    [SerializeField] TextMeshProUGUI attackSpeedText;
    [SerializeField] Image sprite;
    public GameObject panelHolder;
    GameObject parentObj;
    private void Awake()
    {
        panelHolder = GameObject.Find("PanelHolder");
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
        //Application.quitting += SaveDeck;
    }
    void PlayButton()
    {
        SaveDeck();
        SceneManager.LoadScene(1);
    }
    public void UseButton(Button clickButton)
    {
        var parent = clickButton.transform.parent;
        newImage = parent.gameObject;
    }
    public void InfoButton(Button clickButton)
    {
        panelHolder.GetComponent<PanelSwipe>().enabled = false;
        ýnfoPanel.SetActive(true);

        var obj = clickButton.transform.parent;
        parentObj = obj.gameObject;

        string soldierName = parentObj.name + 1;
        string path = parentObj.name + "/" + soldierName;
        Debug.Log(path);

        GameObject variableForPrefab = Resources.Load(path) as GameObject;
        BulletSpawn bulletSpawn = variableForPrefab.GetComponent<BulletSpawn>();

        attackText.text = "" + bulletSpawn.attack;
        attackSpeedText.text = "" + bulletSpawn.attackSpeed;

        sprite.GetComponent<Image>().sprite = parentObj.GetComponent<Image>().sprite;
    }
    public void PanelClose()
    {
        panelHolder.GetComponent<PanelSwipe>().enabled = true;
        ýnfoPanel.SetActive(false);
        parentObj.transform.GetChild(0).gameObject.SetActive(false);
        parentObj.transform.GetChild(1).gameObject.SetActive(false);
        parentObj.transform.GetChild(parentObj.transform.childCount - 1).gameObject.SetActive(true);
        parentObj.transform.GetChild(parentObj.transform.childCount - 2).gameObject.SetActive(true);
    }
    void SaveDeck()
    {
        //if (so.soldiersName.Count > 0)
        //{
        //    so.soldiersName.Clear();
        //}
        for (int i = 0; i < DeckChange.instance.DeckList.Count; i++)
        {
            if (DeckChange.instance.DeckList[i].GetComponent<Image>().sprite == null)
            {
                return;
            }
            so.soldiersName[i] = DeckChange.instance.DeckList[i].name;
        }
        SaveManager.Save(so);
    }
}
