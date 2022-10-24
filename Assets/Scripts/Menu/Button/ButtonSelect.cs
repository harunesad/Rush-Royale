using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonSelect : MonoBehaviour
{
    public static ButtonSelect instance;
    public GameObject useButton;
    public GameObject infoButton;
    public GameObject progressBar;
    public GameObject progressText;
    public GameObject upgradeButton;
    private void Awake()
    {
        instance = this;
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
