using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAction : MonoBehaviour {

    CollisionManager collisionManagerScript;
    [SerializeField]
    EnemyStatus enemyStatusScript;
    [SerializeField]
    BulletStatus bulletStatusScript;
    [SerializeField]
    Rigidbody2D rb2;
    bool isCheck = false;
    void Update()
    {
        CheckMove();
    }

    void CheckMove()
    {
        if(bulletStatusScript.GetStatus() == BulletStatus.Status.Moveing)
        {
            Vector2 force = rb2.velocity;
            float angle = rb2.angularVelocity;
            if (!enemyStatusScript.GetIsCheck())
            {
                enemyStatusScript.SetIsCheck(true);
            }

            else if (force == Vector2.zero && angle == 0.0f && enemyStatusScript.GetIsCheck())
            {
                Debug.Log("STOP");
                bulletStatusScript.SetStatus(BulletStatus.Status.Stop);
                enemyStatusScript.BoardMasterCheckMoveList();
                isCheck = false;
            }
        }
    }

    public void Force(GameObject playerobj)
    {
        float force = playerobj.GetComponent<PlayerStatus>().GetForce();
        Vector2 diff = -playerobj.GetComponent<PlayerStatus>().GetDiff();
    }

    public void SetCollisionManager(CollisionManager set)
    {
        collisionManagerScript = set;
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        collisionManagerScript.CollisionHitEnemy(gameObject,col.gameObject, bulletStatusScript,enemyStatusScript);
    }
}
