/////////////////
//製作者　名越大樹
//クラス名　スコアを管理するクラス
/////////////////

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreManager : MonoBehaviour {

    [SerializeField]
    Score scoreScript;
    [SerializeField]
    UIManager uiManagerScript;

    public void AddScore(int value)
    {
        scoreScript.AddScore(value);
        uiManagerScript.ScoreUpdate();
    }
}
