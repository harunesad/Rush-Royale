using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveControl : GenericSingleton<WaveControl>
{
    public List<GameObject> monsters;
    public bool waveFinish = false;
    void Update()
    {
        if (UIManager.Instance.time <= 0 && !waveFinish)
        {
            for (int i = monsters.Count - 1; i > -1; i--)
            {
                UIManager.Instance.CountRemove();
                Destroy(monsters[i]);
            }
            waveFinish = true;
            monsters.Clear();
            SpawnMonsters.Instance.SpawnRandomBoss();
        }
        if(UIManager.Instance.time > 0)
        {
            waveFinish = false;
            SpawnMonsters.Instance.ReSpawnObj();
        }
    }
}
