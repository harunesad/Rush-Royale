using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UIManager :  State
{
    public static UIManager Instance;
    public TextMeshProUGUI monsterCount;
    //public TextMeshProUGUI costText;
    public TextMeshProUGUI timeText;
    public TextMeshProUGUI waveText;
    //public TextMeshProUGUI costReduceText;
    public TextMeshProUGUI lifeText;
    //public List<TextMeshProUGUI> upgradeText;

    public float time = 40;
    float minute, second;
    //public int wave;
    string count = "*";
    private void Awake()
    {
        Instance = this;
    }
    private void Start()
    {
        //waveText.text = "" + (wave + 1);
        //SpawnMonsters.wave += WaveText;
    }
    //void WaveText()
    //{
    //    waveText.text = "" + (wave + 1);
    //}
    private void Update()
    {
        //TimeControl();
        Run(time > 0);
        minute = Mathf.FloorToInt(time / 60);
        second = Mathf.FloorToInt(time % 60);
        timeText.text = minute + " : " + second;
    }
    public void CountAdd()
    {
        monsterCount.text = monsterCount.text + count;
    }
    public void LifeReduce()
    {
        string currentLife = lifeText.text;
        currentLife = currentLife.Substring(0, currentLife.Length - 1);
        lifeText.text = currentLife;
        _ = currentLife.Length == 0 ? Time.timeScale = 0 : Time.timeScale = 1;
        //if (currentLife.Length == 0)
        //{
        //    Time.timeScale = 0;
        //}
    }
    public void CountRemove()
    {
        string currentCount = monsterCount.text;
        currentCount = currentCount.Substring(0, currentCount.Length - 1);
        monsterCount.text = currentCount;
    }
    void TimeControl()
    {
        if (time > 0)
        {
            time -= Time.deltaTime;
        }
        else
        {
            time = 0;
        }
    }
    public override void StateTrue()
    {
        time -= Time.deltaTime;
    }
    public override void StateFalse()
    {
        time = 0;
    }
}
