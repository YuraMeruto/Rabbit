using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStatus : MonoBehaviour
{
    [SerializeField]
    int count;
    [SerializeField]
    PlayerManager playerManagerScript;
    Vector3 diff;
    [SerializeField]
    float force;
    [SerializeField]
    bool isMove;
    [SerializeField]
    float addForceRate;
    [SerializeField]
    SceneManager sceneManagerscript;
    [SerializeField]
    float lagCount;
    float copyLagCount;
    public float GetAddForceRate()
    {
        return addForceRate;
    }

    public void Subtraction()
    {
        count--;
        playerManagerScript.CountUpdate();
    }
    public int GetCount()
    {
        return count;
    }

    public void SetDiff(Vector2 set)
    {
        diff = set;
    }

    public Vector2 GetDiff()
    {
        return diff;
    }

    public void SetForce(float set)
    {
        force = set;
    }

    public float GetForce()
    {
        return force;
    }

    public void SetBulletForce(float setforce,Vector2 setdiff,bool setismove)
    {
        force = setforce;
        diff = setdiff;
        isMove = setismove;
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
        force -= Time.deltaTime / 5;
        if(force <= 0.0f)
        {
            isMove = false;
        }
    }

  

    public void SetIsMove(bool set)
    {
        isMove = set;
    }

    public void BoardManagerAddMoveList()
    {
        playerManagerScript.AddMoveList(gameObject);
    }

    public void BoardManagerCheckMoveList()
    {
        playerManagerScript.CheckMoveList(gameObject);
    }

    public void UIManagerChargeGageUpdate(float value)
    {
        playerManagerScript.ChargeGageUpdate(value);
    }

    public void SceneStage(SceneManager.SceneName status)
    {
        playerManagerScript.SceneStage(status);
    }

    public CollisionManager GetCollisionManager()
    {
        return playerManagerScript.GetCollisionManager();
    }

    public void SetPlayerManager(PlayerManager set)
    {
        playerManagerScript = set;
    }

    public PlayerManager GetPlayerManager()
    {
        return playerManagerScript;
    }

    public float GetLagCount()
    {
        return lagCount;
    }

    public void SetLagCount(float set)
    {
        lagCount = set;
    }

    public void ResetLagCount()
    {
        lagCount = copyLagCount;
    }
}

