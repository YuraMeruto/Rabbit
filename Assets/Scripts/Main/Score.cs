﻿///////////////////////
//製作者　名越大樹
//クラス名 スコアに関するクラス
//////////////////////
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Score : MonoBehaviour {

    int score = 0;

    public void AddScore(int value)
    {
        score += value;
    }

    public int GetScore()
    {
        return score;
    }
}
