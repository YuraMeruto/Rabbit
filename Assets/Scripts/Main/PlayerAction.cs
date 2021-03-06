﻿/////////////////////////////////
//制作者　名越大樹
//製作日　10月19日
//プレイヤーの操作に関するスクリプト
////////////////////////////////

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Threading;
public class PlayerAction : MonoBehaviour
{
    [SerializeField]
    bool isCharge = false;
    [SerializeField]
    bool isAction = true;
    float addForce = 0.0f;
    [SerializeField]
    PlayerBullet playerBulletScript;
    Vector2 buttonDownPosition;
    [SerializeField]
    PlayerStatus playerStatusScript;
    [SerializeField]
    float addForceSpeed;
    [SerializeField]
    PostRequest postRequestScript;
    [SerializeField]
    ReadData readDataScript;
    bool isScene = false;
    SceneManager.SceneName sceneStatus;
    [SerializeField]
    GameObject arrowObj;
    GameObject copyArrowObj;
    [SerializeField]
    GameObject playerBulletObj;
    [SerializeField]
    PlayerManager playerManagerScript;
    [SerializeField]
    float requestTime;

    void Update()
    {
        Key();
        ChargeUpdate();
        Scene();
    }

    void Key()
    {
        if (Input.GetMouseButtonDown(0) && isAction)
        {
            buttonDownPosition = Camera.main.WorldToViewportPoint(Input.mousePosition);
            isCharge = true;
            isAction = false;
            GameObject instanceobj = Instantiate(arrowObj, playerBulletObj.transform.position, Quaternion.identity);
            copyArrowObj = instanceobj;
        }

        else if (Input.GetMouseButtonUp(0))
        {
            Destroy(copyArrowObj);
            Fire();
        }

        if(Input.GetKeyDown(KeyCode.Space))
        {
            SendRequest();
        }
    }

    /// <summary>
    /// プレイヤーの弾に加える力の更新
    /// </summary>
    void ChargeUpdate()
    {
        if (isCharge)
        {
            addForce += Time.deltaTime * addForceSpeed;
            if (addForce >= 1.0f)
            {
                addForce = 0.0f;
            }
            playerStatusScript.UIManagerChargeGageUpdate(addForce);
        }
    }

    void Fire()
    {
        if (playerStatusScript.GetCount() != 0 && isCharge)
        {
            Vector2 buttonupPos = Camera.main.WorldToViewportPoint(Input.mousePosition);
            Vector2 direction = (buttonDownPosition - buttonupPos).normalized;
            playerBulletScript.Fire(addForce, direction);
            addForce = 0.0f;
            isCharge = false;
        }
    }

    public void SetIsAction(bool set)
    {
        isAction = set;
    }

    /// <summary>
    /// ボード上に敵の弾か残りの弾の残機がゼロになったときの処理
    /// </summary>
    void Scene()
    {
        if (isScene)
        {
            playerStatusScript.SceneStage(sceneStatus);
        }
    }

    public void SendRequest()
    {
        string result = readDataScript.Read();
        string[] splitresult = result.Split(',');
        Debug.Log(splitresult[0]);
        /*
        Dictionary<string, string> set = new Dictionary<string, string>();
        set.Add("id", splitresult[0]);
        string url = "http:/localhost/ScoreResponse,php";
        playerManagerScript.SendRequest(set,requestTime,url);
        Thread postthread = new Thread(ThreadRequest);
        postthread.Start();
        */

    }

    void ThreadRequest()
    {
        PostRequest.Status result = PostRequest.Status.None;
        while (postRequestScript.GetStatus() == PostRequest.Status.None)
        {
            result = postRequestScript.GetStatus();
        }
        switch (result)
        {
            case PostRequest.Status.Sucsess:
                isScene = true;
                break;
        }
    }

    public void SetPlayerBullet(GameObject bulletobj)
     {
        playerStatusScript = bulletobj.GetComponent<PlayerStatus>();
        playerBulletScript = bulletobj.GetComponent<PlayerBullet>();
        playerBulletObj = bulletobj;
        playerStatusScript.SetPlayerManager(playerManagerScript);
        playerBulletScript.SetCollisionManager(playerStatusScript.GetCollisionManager());
        
    }
}
