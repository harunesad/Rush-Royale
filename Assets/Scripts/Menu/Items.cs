using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class Items : MonoBehaviour
{
    public static Items item;
    public TextMeshProUGUI coinText;
    public TextMeshProUGUI crystalText;
    public TextMeshProUGUI coinAddText;
    public TextMeshProUGUI crystalAddText;
    public TextMeshProUGUI storeCoinAddText;
    public TextMeshProUGUI storeCrystalAddText;
    public int chestNumber;
    private void Awake()
    {
        item = this;
    }
    void Start()
    {
        coinText.text = "" + PlayerPrefs.GetInt("Coin");
        crystalText.text = "" + PlayerPrefs.GetInt("Crystal");
        if (PlayerPrefs.HasKey("ChestNumber"))
        {
            chestNumber = PlayerPrefs.GetInt("ChestNumber");
        }
    }
    public void ChestCoin(int min, int max, string save)
    {
        int randomCoin = Random.Range(min, max);
        coinAddText.text = "" + randomCoin;
        int coin = PlayerPrefs.GetInt("Coin");
        coin += randomCoin;
        PlayerPrefs.SetInt("Coin", coin);
        coinText.text = "" + PlayerPrefs.GetInt(save);
    }
    public void ChestCrystal(int min, int max, string save)
    {
        int randomCrystal = Random.Range(min, max);
        crystalAddText.text = "" + randomCrystal;
        int crystal = PlayerPrefs.GetInt("Crystal");
        crystal += randomCrystal;
        PlayerPrefs.SetInt("Crystal", crystal);
        crystalText.text = "" + PlayerPrefs.GetInt(save);
    }
    public void StoreChestCoin(int min, int max, string save)
    {
        int randomCoin = Random.Range(min, max);
        storeCoinAddText.text = "" + randomCoin;
        int coin = PlayerPrefs.GetInt("Coin");
        coin += randomCoin;
        PlayerPrefs.SetInt("Coin", coin);
        coinText.text = "" + PlayerPrefs.GetInt(save);
    }
    public void StoreChestCrystal(int min, int max, string save)
    {
        int randomCrystal = Random.Range(min, max);
        storeCrystalAddText.text = "" + randomCrystal;
        int crystal = PlayerPrefs.GetInt("Crystal");
        crystal += randomCrystal;
        PlayerPrefs.SetInt("Crystal", crystal);
        crystalText.text = "" + PlayerPrefs.GetInt(save);
    }
    void Update()
    {
        
    }
}
