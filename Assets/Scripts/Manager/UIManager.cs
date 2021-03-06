﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour {

    [SerializeField]
    PlayerManager playerManagerScript;
    [SerializeField]
    PlayerUI playerUIScript;
    [SerializeField]
    ScoreUI scoreUIScript;
    public int GetPlayerCount()
    {
        return playerManagerScript.GetPlayerCount();
    }
    
    public void CountUpdate()
    {
        playerUIScript.CountUpdate();
    }

    public void ScoreUpdate()
    {
        scoreUIScript.ScoreUpdate();
    }

    public void ChargeGageUpdate(float value)
    {
        playerUIScript.ChargeGageUpdate(value);
    }

    public void Ini()
    {
        ScoreUpdate();
        CountUpdate();
    }
}
