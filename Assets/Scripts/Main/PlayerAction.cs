/////////////////////////
//制作者　名越大樹
//製作日　10月19日
//プレイヤーの操作に関する宿里プt
/////////////////////////
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
    void Update()
    {
        Key();
        Charge();
        Scene();
    }

    void Key()
    {
        if (Input.GetMouseButtonDown(0) && isAction)
        {
            buttonDownPosition = Camera.main.WorldToViewportPoint(Input.mousePosition);
            isCharge = true;
            isAction = false;
            GameObject instanceobj = Instantiate(arrowObj,playerBulletObj.transform.position,Quaternion.identity);
            copyArrowObj = instanceobj;
        }

        else if (Input.GetMouseButtonUp(0))
        {
            Destroy(copyArrowObj);
            Fire();
        }
    }

    void Charge()
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
    void Scene()
    {
        if(isScene)
        {
            playerStatusScript.SceneStage(sceneStatus);
        }
    }

    public void SendRequest()
    {
        string result = readDataScript.Read();
        string[] splitresult = result.Split(',');
        Dictionary<string, string> set = new Dictionary<string, string>();
        set.Add("id", splitresult[0]);
        string url = "http:/localhost/ScoreResponse,php";
        postRequestScript.SendData(set, 5, url);
        Thread postthread = new Thread(ThreadRequest);
        postthread.Start();
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


}
