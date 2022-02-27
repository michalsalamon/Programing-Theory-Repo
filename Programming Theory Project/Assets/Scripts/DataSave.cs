using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataSave : MonoBehaviour
{
    public static DataSave Instance;

    private string playerName;
    public string PlayerName    //ENCAPSULATION
    {
        get { return playerName; }
        set { playerName = value; }
    }
    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
        DontDestroyOnLoad(gameObject);
    }
}
