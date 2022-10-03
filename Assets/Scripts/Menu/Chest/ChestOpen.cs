using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChestOpen : MonoBehaviour
{
    public int chestProgress;
    void Start()
    {
        if (PlayerPrefs.GetInt("Coin") >= chestProgress)
        {
            gameObject.transform.GetChild(0).gameObject.SetActive(false);
            gameObject.AddComponent<Button>();
            gameObject.GetComponent<Button>().onClick.AddListener(ChestClick);
        }
    }
    void Update()
    {

    }
    void ChestClick()
    {

    }
}
