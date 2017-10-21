/////////////////////////
//制作者　名越大樹
//製作日　10月19日
/////////////////////////

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionManager : MonoBehaviour {

    [SerializeField]
    BoundManager boundManagerScript;

    /// <summary>
    /// プレイヤーがほかのオブジェクトあった時のメソッド
    /// </summary>
    public void CollisionHitPlayer(GameObject playerobj,GameObject hitobj)
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
        else if (hitobj.tag == "Enemy")
        {
            playerobj.GetComponent<PlayerStatus>().InvertedDiff();
            hitobj.GetComponent<Enemy>().Force(playerobj);
        }
        */
    }

    /// <summary>
    /// 敵がほかのオブジェクトに当たったときのオブジェクト
    /// </summary>
    public void CollisionHitEnemy(GameObject enemyobj, GameObject hitobj)
    {
        if(hitobj.tag == "Wall")
        {
            enemyobj.GetComponent<EnemyStatus>().InvertedDiff();
        }
    }

}
