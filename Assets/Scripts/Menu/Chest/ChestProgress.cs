using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChestProgress : MonoBehaviour
{
    public Image chestProgressBar;
    void Start()
    {
        if (PlayerPrefs.GetInt("Progress") != 0)
        {
            int newBar = 10000 / PlayerPrefs.GetInt("Progress");
            chestProgressBar.fillAmount = 1 / (float)newBar;
        }
    }
    void Update()
    {
        
    }
}
