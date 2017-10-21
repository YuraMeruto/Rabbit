/////////////////////////
//制作者　名越大樹
//製作日　10月19日
//プレイヤーの操作に関する宿里プt
/////////////////////////
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAction : MonoBehaviour
{
    bool isCharge = true;
    float addForce = 0.0f;
    [SerializeField]
    PlayerBullet playerBulletScript;
    Vector2 buttonDownPosition;
    [SerializeField]
    PlayerStatus playerStatusScript;
    void Update()
    {
        Key();
        Charge();
    }

    void Key()
    {
        if (Input.GetMouseButtonDown(0))
        {
            buttonDownPosition = Input.mousePosition;
            isCharge = true;
        }

        else if (Input.GetMouseButtonUp(0))
        {
            isCharge = false;
            Fire();
        }
    }

    void Charge()
    {
        if(isCharge)
        {
            addForce += Time.deltaTime;
        }
    }
    void Fire()
    {
        Vector2 buttonupPos = Input.mousePosition;
        Vector2 direction = (buttonDownPosition - buttonupPos).normalized;
        playerBulletScript.Fire(addForce,direction);
        playerStatusScript.Subtraction();
        addForce = 0.0f;
    }
}
