﻿////////////////////////////
//制作者　名越大樹
//製作日　10月19日
//クラス名　プレイヤー全体を管理するクラス
////////////////////////////

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour {

    [SerializeField]
    UIManager uiManagerScript;
    [SerializeField]
    BoardManager boardManagerScript;
    [SerializeField]
    PlayerAction playerActionScript;
    [SerializeField]
    SceneManager sceneManagerScript;
    [SerializeField]
    PostManager postManagerScript;
    PlayerStatus playerStatusScript;
    [SerializeField]
    CollisionManager collisionManagerScript;
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

    public void SetIsAction(bool set)
    {
        playerActionScript.SetIsAction(set);
    }

    public void ChargeGageUpdate(float value)
    {
        uiManagerScript.ChargeGageUpdate(value);
    }

    public void SendScore()
    {
        playerActionScript.SendRequest();
    }

    public void SceneStage(SceneManager.SceneName status)
    {
        sceneManagerScript.SceneStage(status);
    }

    public void CountSubtraction()
    {
        playerStatusScript.Subtraction();
    }

    /// <summary>
    /// ゲームが終了した時サーバー上にスコアのデータを送る処理
    /// </summary>
    public void SendRequest(Dictionary<string,string> data,float time,string url)
    {
        postManagerScript.SendRequest(data,time,url);
    }

    public void SetPlayerStatus(PlayerStatus status)
    {
        playerStatusScript = status;
    }

    public void Ini(GameObject player)
    {
        SetPlayerStatus(player.GetComponent<PlayerStatus>());
        playerActionScript.SetPlayerBullet(player);
    }

    public CollisionManager GetCollisionManager()
    {
        return collisionManagerScript;
    }
}
