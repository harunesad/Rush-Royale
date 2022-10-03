using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class ButtonClick : MonoBehaviour
{
    public static ButtonClick instance;
    //public Button clickButton;
    public GameObject newImage;
    GameObject playButton;
    public SaveObject so;
    [SerializeField] GameObject ýnfoPanel;
    [SerializeField] TextMeshProUGUI attackText;
    [SerializeField] TextMeshProUGUI attackSpeedText;
    [SerializeField] Image sprite;
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
        Application.quitting += SaveDeck;
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
        ýnfoPanel.SetActive(true);

        var obj = clickButton.transform.parent;
        GameObject parent = obj.gameObject;

        string soldierName = parent.name + 1;
        string path = parent.name + "/" + soldierName;
        Debug.Log(path);

        GameObject variableForPrefab = Resources.Load(path) as GameObject;
        BulletSpawn bulletSpawn = variableForPrefab.GetComponent<BulletSpawn>();

        attackText.text = "" + bulletSpawn.attack;
        attackSpeedText.text = "" + bulletSpawn.attackSpeed;

        sprite.GetComponent<Image>().sprite = parent.GetComponent<Image>().sprite;
    }
    public void PanelClose()
    {
        ýnfoPanel.SetActive(false);
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
