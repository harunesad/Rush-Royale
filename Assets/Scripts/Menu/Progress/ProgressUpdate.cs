using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class ProgressUpdate : MonoBehaviour
{
    //public TextMeshProUGUI progressText;
    void Start()
    {
        GameObject parent = gameObject.transform.parent.gameObject;
        string path = gameObject.name + "/" + (gameObject.name + 1);
        GameObject variableForPrefab = Resources.Load(path) as GameObject;
        UpgradeProgress progress = variableForPrefab.GetComponent<UpgradeProgress>();
        gameObject.transform.GetChild(3).GetComponent<TextMeshProUGUI>().text = progress.myCountCard + "/" + progress.upgradeCountCard;
        gameObject.transform.GetChild(2).GetComponent<Image>().fillAmount = progress.myCountCard / progress.upgradeCountCard;
    }
    void Update()
    {
        
    }
}
