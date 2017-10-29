///////////////////////////
//制作者　名越大樹
//クラス名　サーバーからスコアを入手
///////////////////////////
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Threading;
using UnityEngine.UI;
public class GetScore : MonoBehaviour
{
    [SerializeField]
    string url;
    [SerializeField]
    PostRequest postRequestScript;
    [SerializeField]
    int limit;
    [SerializeField]
    string message;
    [SerializeField]
    Text[] scoreArray;
    [SerializeField]
    bool isUpdate = false;
    [SerializeField]
    bool isResponse = false;
    string username;
    [SerializeField]
    ReadData readDataScript;
    void Start()
    {
        Dictionary<string, string> dic = new Dictionary<string, string>();
        dic.Add("limit",limit.ToString());
        readDataScript.Read();
        Thread check = new Thread(CheckResponse);
        postRequestScript.SendData(dic, limit, url);
        check.Start();
    }

    void Update()
    {
        if(isUpdate)
        {
            TextUpdate();
        }
    }

    void TextUpdate()
    {
        string[] result = message.Split('/');
        Debug.Log(result.Length);
        for(int count = 0;count < result.Length;count++)
        {
            Debug.Log(count);
            scoreArray[count].text = result[count];
        }
        isUpdate = false;
    }

    void CheckResponse()
    {
        while (!isResponse)
        {
            PostRequest.Status status = postRequestScript.GetStatus();
            if(status == PostRequest.Status.Sucsess)
            {
                isResponse = true;
            }
        }
        message = postRequestScript.GetResponse();
        isUpdate = true;
    }
}
