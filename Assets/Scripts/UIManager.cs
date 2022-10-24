using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UIManager :  State
{
    public static UIManager Instance;
    public TextMeshProUGUI monsterCount;
    public TextMeshProUGUI timeText;
    public TextMeshProUGUI waveText;
    public TextMeshProUGUI lifeText;
    public GameObject gameOverPanel;

    public float time = 40;
    float minute, second;
    string count = "*";
    private void Awake()
    {
        Instance = this;
    }
    private void Start()
    {
        DieMonster.bossDie += ReTime;
    }
    private void Update()
    {
        Run(time > 0);
        minute = Mathf.FloorToInt(time / 60);
        second = Mathf.FloorToInt(time % 60);
        timeText.text = minute + " : " + second;
    }
    void ReTime()
    {
        time = 20;
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
        if (currentLife.Length == 0)
        {
            Time.timeScale = 0;
            gameOverPanel.SetActive(true);
            TextMeshProUGUI coinText = gameOverPanel.transform.GetChild(0).GetComponent<TextMeshProUGUI>();
            TextMeshProUGUI coinIncText = gameOverPanel.transform.GetChild(1).GetComponent<TextMeshProUGUI>();
            TextMeshProUGUI crystalText = gameOverPanel.transform.GetChild(2).GetComponent<TextMeshProUGUI>();
            TextMeshProUGUI crystalIncText = gameOverPanel.transform.GetChild(3).GetComponent<TextMeshProUGUI>();
            coinText.text = "" + PlayerPrefs.GetInt("Coin");
            coinIncText.text = "" + WaveControl.Instance.coin;
            crystalText.text = "" + PlayerPrefs.GetInt("Crystal");
            crystalIncText.text = "" + WaveControl.Instance.crystal;
        }
        //_ = currentLife.Length == 0 ? Time.timeScale = 0 : Time.timeScale = 1;
    }
    public void CountRemove()
    {
        string currentCount = monsterCount.text;
        currentCount = currentCount.Substring(0, currentCount.Length - 1);
        monsterCount.text = currentCount;
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
