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

}

