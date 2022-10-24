using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class JsonSave : MonoBehaviour
{
    public SaveObject so;
    public int save;
    private void Awake()
    {
        save = PlayerPrefs.GetInt("State");
        if (save == 1)
        {
            SceneManager.LoadScene(save);
        }
        if (save == 0)
        {
            save++;
            SaveManager.Save(so);
            SceneManager.LoadScene(1);
            PlayerPrefs.SetInt("State", save);
        }
    }
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
