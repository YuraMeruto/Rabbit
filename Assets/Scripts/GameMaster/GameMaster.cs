using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameMaster : MonoBehaviour
{

    [SerializeField]
    bool isGamePlay;
    [SerializeField]
    IniSet iniSetScript;
    void Start()
    {
        iniSetScript.Ini();
    }
    public void SetIsGamePlay(bool set)
    {
        isGamePlay = set;
    }

    public bool GetIsGamePlay()
    {
        return isGamePlay;
    }

    public void Ini()
    {

    }
}
