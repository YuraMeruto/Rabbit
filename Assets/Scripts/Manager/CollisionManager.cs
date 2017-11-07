/////////////////////////
//制作者　名越大樹
//クラス名　ボード上にアルすべての当たり判定のイベントに関するクラス
/////////////////////////

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionManager : MonoBehaviour {

    [SerializeField]
    BoundManager boundManagerScript;
    [SerializeField]
    BoardManager boardManagerScript;
    [SerializeField]
    EnemyManager enemyManagerScript;
    [SerializeField]
    UIManager uiManagerScript;
    [SerializeField]
    ScoreManager scoreManagerScript;

    /// <summary>
    /// プレイヤーがほかのオブジェクトあった時のメソッド
    /// </summary>
    public void CollisionHitPlayer(GameObject playerobj,GameObject hitobj,PlayerStatus status)
    {/*
        if (hitobj.tag == "Bound")
        {
            playerobj.GetComponent<PlayerBullet>().Bound(boundManagerScript.GetBoundForce());
        }
        else if(hitobj.tag == "Wall")
        {
            float x = Random.RandomRange(-1.0f,1.0f);
            float y = Random.RandomRange(-1.0f, 1.0f);
            Vector2 pos;
            pos.x = x;
            pos.y = y;
            playerobj.GetComponent<PlayerStatus>().InvertedDiff();
            playerobj.GetComponent<PlayerStatus>().SetDiff(pos);
        }
     */
     if(hitobj.tag == "Wall")
        {
            status.Subtraction();
        }
    }

    /// <summary>
    /// 敵がほかのオブジェクトに当たったときのオブジェクト
    /// </summary>
    public void CollisionHitEnemy(GameObject enemyobj, GameObject hitobj,BulletStatus status,EnemyStatus enemystatus)
    {
        if(hitobj.tag == "Wall")
        {
            scoreManagerScript.AddScore(enemystatus.GetScore());
            enemyManagerScript.RemoveEnemy(enemyobj);
            boardManagerScript.CheckMoveList(enemyobj);
        }

        else if(hitobj.tag == "Player")
        {
            status.SetStatus(BulletStatus.Status.Moveing);
            boardManagerScript.AddMoveList(enemyobj);
        }

        else if (hitobj.tag == "Enemy")
        {
            status.SetStatus(BulletStatus.Status.Moveing);
            boardManagerScript.AddMoveList(enemyobj);
            enemystatus.SetIsCheck(false);
        }

    }
}
