using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class WaveControl : GenericSingleton<WaveControl>
{
    public bool waveFinish = false;
    public TextMeshProUGUI waveText;
    public int wave;
    private void Start()
    {
        waveText.text = "" + (wave + 1);
        MonsterDieState.wave += WaveText;
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
        }
        if (UIManager.Instance.time > 0)
        {
            waveFinish = false;
            SpawnMonsters.Instance.ReSpawnObj();
        }
    }
}
