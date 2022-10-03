using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class WaveControl : GenericSingleton<WaveControl>
{
    public bool waveFinish = false;
    public TextMeshProUGUI waveText;
    public int wave;
    int coin;
    int load;
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
            coin = wave * 100;
            load = PlayerPrefs.GetInt("Coin");
            load += coin;
            PlayerPrefs.SetInt("Coin", load);
            Debug.Log(PlayerPrefs.GetInt("Coin"));
        }
        if (UIManager.Instance.time > 0)
        {
            waveFinish = false;
            SpawnMonsters.Instance.ReSpawnObj();
        }
    }
}
