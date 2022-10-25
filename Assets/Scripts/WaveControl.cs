using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class WaveControl : MonoBehaviour
{
    public static WaveControl Instance;
    public bool waveFinish = false;
    public TextMeshProUGUI waveText;
    public int wave;
    int progress;
    int progressChest;
    public int coin;
    int coinProgress;
    public int crystal;
    int crystalProgress;
    private void Awake()
    {
        Instance = this;
    }
    private void Start()
    {
        waveText.text = "" + (wave + 1);
        DieMonster.bossDie += WaveText;
    }
    void WaveText()
    {
        waveText.text = "" + (wave + 1);
    }
    void Update()
    {
        if (UIManager.Instance.time <= 0 && !waveFinish)
        {
            SpawnMonsters.Instance.MonstersDestroy();
            waveFinish = true;
            SpawnMonsters.Instance.SpawnRandomBoss();
            MonsterHealthManager.Instance.HealthIncrease();
            wave++;
            ProgressChest();
            CoinProgress();
            CrystalProgress();
        }
        if (UIManager.Instance.time > 0)
        {
            waveFinish = false;
            SpawnMonsters.Instance.ReSpawnObj();
        }
    }
    void ProgressChest()
    {
        progress = wave * 10;
        progressChest = PlayerPrefs.GetInt("Progress");
        progressChest += progress;
        PlayerPrefs.SetInt("Progress", progressChest);
        Debug.Log(PlayerPrefs.GetInt("Progress"));
    }
    void CoinProgress()
    {
        coin = wave * Random.Range(10, 21);
        coinProgress = PlayerPrefs.GetInt("Coin");
        coinProgress += coin;
        PlayerPrefs.SetInt("Coin", coinProgress);
    }
    void CrystalProgress()
    {
        crystal = wave * Random.Range(1, 6);
        crystalProgress = PlayerPrefs.GetInt("Crystal");
        crystalProgress += crystal;
        PlayerPrefs.SetInt("Crystal", crystalProgress);
    }
}
