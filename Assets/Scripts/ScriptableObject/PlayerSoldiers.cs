using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "PlayerSoldiers", menuName = "ScritableObject/PlayerSoldiers")]
public class PlayerSoldiers : ScriptableObject
{
    public List<GameObject> firstObj;
    public List<GameObject> secondObj;
    public List<GameObject> thirdObj;
    public List<GameObject> fourthObj;
}
