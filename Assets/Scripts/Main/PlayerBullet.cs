using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBullet : MonoBehaviour
{

    [SerializeField]
    Rigidbody2D rb2;
    [SerializeField]
    CollisionManager collisonManagerScript;
    [SerializeField]
    PlayerStatus playerStatusScript;
    [SerializeField]   
    bool isMove = false;
    [SerializeField]
    BulletStatus bulletStatusScript;
    int count = 0;
    void Update()
    {
        CheckMove();
    }

    public void Fire(float force, Vector3 direction)
    {
        rb2.AddForce(direction * force * 1000);
        bulletStatusScript.SetStatus(BulletStatus.Status.Moveing);
        playerStatusScript.SetIsMove(false);
        playerStatusScript.BoardManagerAddMoveList();
    }

    void CheckMove()
    {
        BulletStatus.Status status = bulletStatusScript.GetStatus();
        Vector2 force = rb2.velocity;
        float quatunion = rb2.angularVelocity;
        if (status == BulletStatus.Status.Moveing)
        {
            if (count == 0)
            {

                count++;
            }

            else if (force == Vector2.zero && quatunion == 0.0f)
            {
                Debug.Log("STOP");
                bulletStatusScript.SetStatus(BulletStatus.Status.Stop);
                playerStatusScript.BoardManagerCheckMoveList();
                count = 0;
            }
        }
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        collisonManagerScript.CollisionHitPlayer(gameObject, col.gameObject,playerStatusScript);
    }
}
