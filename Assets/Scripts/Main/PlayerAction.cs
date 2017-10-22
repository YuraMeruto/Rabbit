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
    [SerializeField]
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
        }

        else if (Input.GetMouseButtonUp(0))
        {
            Fire();
        }
    }

    void Charge()
    {
        if (isCharge)
        {
            addForce += Time.deltaTime;
        }
    }
    void Fire()
    {
        if (playerStatusScript.GetCount() != 0 && isCharge)
        {
            Vector2 buttonupPos = Input.mousePosition;
            Vector2 direction = (buttonDownPosition - buttonupPos).normalized;
            playerBulletScript.Fire(addForce, direction);
            playerStatusScript.Subtraction();
            addForce = 0.0f;
            isCharge = false;
        }
    }

    public void SetIsCharge(bool set)
    {
        isCharge = set;
    }
}
