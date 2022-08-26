using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UIManager : GenericSingleton<UIManager>
{
    public TextMeshProUGUI monsterCount;
    public TextMeshProUGUI costText;
    public TextMeshProUGUI timeText;
    public float time = 40;
    float minute, second;
    string count = "*";
    private void Update()
    {
        if (time > 0)
        {
            time -= Time.deltaTime;
        }
        else
        {
            time = 0;    
        }
        minute = Mathf.FloorToInt(time / 60);
        second = Mathf.FloorToInt(time % 60);
        timeText.text = minute + " : " + second;
    }
    public void CountAdd()
    {
        monsterCount.text = monsterCount.text + count;
    }
    public void CountRemove()
    {
        string currentCount = monsterCount.text;
        currentCount = currentCount.Substring(0, currentCount.Length - 1);
        monsterCount.text = currentCount;
    }
}
