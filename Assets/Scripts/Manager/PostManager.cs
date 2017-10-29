///////////////////////
//製作者　名越大樹
//POST  リクエストに関するクラス
///////////////////////

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PostManager : MonoBehaviour {

    [SerializeField]
    PostRequest postRequestScript;
    [SerializeField]
    public void SendRequest(Dictionary<string,string> data,float time, string url)
    {
        postRequestScript.SendData(data,time,url);
    }
}
