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
    void Update()
    {
        Move();
    }
    public void Fire(float force, Vector3 direction)
    {
        playerStatusScript.SetBulletForce(force,direction,true);
    }

    void Move()
    {
        if(playerStatusScript.GetIsMove())
        {
            float force = playerStatusScript.GetForce();
            Vector2 diff = playerStatusScript.GetDiff();
            transform.Translate(diff * force, Space.World);
            playerStatusScript.ForceCount();
        }
    }

    public void Bound(float boundforce)
    {
        Vector3 getdiff = playerStatusScript.GetDiff();
        playerStatusScript.SetForce(boundforce);
        playerStatusScript.SetDiff(-getdiff);
    }
    
    void OnCollisionEnter2D(Collision2D col)
    {
        collisonManagerScript.CollisionHitPlayer(gameObject, col.gameObject);
    }
}
