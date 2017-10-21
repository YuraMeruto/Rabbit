////////////////////////////
//制作者　名越大樹
//製作日　10月19日
//クラス名　プレイヤー全体を管理するクラス
////////////////////////////
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour {

    [SerializeField]
    PlayerStatus playerStatusScript;
    [SerializeField]
    UIManager uiManagerScript;

    public int GetPlayerCount()
    {
        return playerStatusScript.GetCount();
    }

    public void CountUpdate()
    {

    }
}
