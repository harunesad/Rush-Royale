using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChestProgress : MonoBehaviour
{
    public Image chestProgressBar;
    void Start()
    {
        int newBar = 10000 / PlayerPrefs.GetInt("Coin");
        chestProgressBar.fillAmount = 1 / (float)newBar;
    }
    void Update()
    {
        
    }
}
