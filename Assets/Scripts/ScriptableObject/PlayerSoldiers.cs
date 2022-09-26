using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "PlayerSoldiers", menuName = "ScritableObject/PlayerSoldiers")]
public class PlayerSoldiers : ScriptableObject
{
    public List<GameObject> starObj;
    public List<GameObject> plusObj;
    public List<GameObject> minusObj;
    public List<GameObject> divideObj;
}
