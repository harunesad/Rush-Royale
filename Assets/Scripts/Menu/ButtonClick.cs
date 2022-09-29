using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ButtonClick : MonoBehaviour
{
    GameObject playButton;
    //GameObject 
    private void Awake()
    {
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
}
