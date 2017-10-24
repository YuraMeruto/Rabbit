//////////////////////
//製作者　名越大樹
//クラス名　ボード上にある弾の状態に関するクラス
//////////////////////

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletStatus : MonoBehaviour {

    [SerializeField]
        Status status;

    public enum Status
    {
        None,
        Moveing,
        Stop
    }

    public void SetStatus(Status set)
    {
        status = set;
    }

    public Status GetStatus()
    {
        return status;
    }
}
