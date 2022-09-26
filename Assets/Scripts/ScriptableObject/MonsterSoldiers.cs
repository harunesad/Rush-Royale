using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "MonsterSoldiers", menuName = "ScritableObject/MonsterSoldiers")]
public class MonsterSoldiers : ScriptableObject
{
    public List<GameObject> spawnMonsters;
    public List<GameObject> bossMonster;
}
