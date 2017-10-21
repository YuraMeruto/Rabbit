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

    public void SetForce(float set)
    {
        force = set;
    }

    public float GetForce()
    {
        return force;
    }

    public void SetBulletForce(float setforce, Vector2 setdiff, bool setismove)
    {
        force = setforce;
        diff = setdiff;
        isMove = setismove;
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

    public void ForceCount()
    {
        force -= Time.deltaTime;
        if(force <=0.0f)
            {
            isMove = false;
            }
    }
}
