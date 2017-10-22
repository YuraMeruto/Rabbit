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
    [SerializeField]
    BoardManager boardManagerScript;
    [SerializeField]
    PlayerAction playerActionScript;
    public int GetPlayerCount()
    {
        return playerStatusScript.GetCount();
    }

    public void CountUpdate()
    {
        uiManagerScript.CountUpdate();
    }

    public void AddMoveList(GameObject obj)
    {
        boardManagerScript.AddMoveList(obj);
    }

    public void CheckMoveList(GameObject obj)
    {
        boardManagerScript.CheckMoveList(obj);
    }

    public void SetIsCharge(bool set)
    {
        playerActionScript.SetIsCharge(set);
    }
}
