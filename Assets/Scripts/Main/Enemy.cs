using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {

    [SerializeField]
    CollisionManager collisionManagerScript;
    [SerializeField]
    EnemyStatus enemyStatusScript;

    void Update()
    {
        Move();
    }

    void Move()
    {
        if(enemyStatusScript.GetIsMove())
        {
            float force = enemyStatusScript.GetForce();
            Vector2 diff = enemyStatusScript.GetDiff();
            transform.Translate(diff * force,Space.World);
            enemyStatusScript.ForceCount();
        }
    }
    public void Force(GameObject playerobj)
    {
        float force = playerobj.GetComponent<PlayerStatus>().GetForce();
        Vector2 diff = -playerobj.GetComponent<PlayerStatus>().GetDiff();
        enemyStatusScript.SetBulletForce(force,diff,true);
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        collisionManagerScript.CollisionHitEnemy(gameObject,col.gameObject);
    }
}
