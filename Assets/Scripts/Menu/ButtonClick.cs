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
        Debug.Log(playButton.name);
        SceneManager.LoadScene(1);
    }
    public void UseButton(Button clickButton)
    {
        var parent = clickButton.transform.parent;
        newImage = parent.gameObject;
    }
}
