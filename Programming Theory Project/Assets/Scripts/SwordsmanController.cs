using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordsmanController : Unit
{
    // Start is called before the first frame update
    void Start()
    {
        owner = DataSave.Instance.PlayerName;
    }
}
