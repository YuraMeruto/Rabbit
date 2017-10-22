//////////////////////////
//制作者　名越大樹
//製作日　10月19日
//クラス名　エネミーのステータスに関するクラス
//////////////////////////

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStatus : MonoBehaviour {

    float force;
    bool isMove;
    Vector3 diff;
    [SerializeField]
    int score;
    [SerializeField]
    EnemyManager enemyManagerScript;
    bool isCheck = false;

    public void SetForce(float set)
    {
        force = set;
    }

    public float GetForce()
    {
        return force;
    }

    public void SetIsMove(bool set)
    {
        isMove = set;
    }

    public void SetDiff(Vector2 set)
    {
        diff = set;
    }

    public Vector2 GetDiff()
    {
        return diff;
    }

    public void InvertedDiff()
    {
        diff = -diff;
    }

    public bool GetIsMove()
    {
        return isMove;
    }

    public void BoardMasterCheckMoveList()
    {
        enemyManagerScript.CheckMoveList(gameObject);
    }

    public bool GetIsCheck()
    {
        return isCheck;
    }

    public void SetIsCheck(bool set)
    {
        isCheck = set;
    }

    public int GetScore()
    {
        return score;
    }
}
