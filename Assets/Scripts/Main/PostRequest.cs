//////////////////////
//製作者　名越大樹
//クラス名　サーバー上のPOSTに送信するクラス
//////////////////////
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PostRequest : MonoBehaviour {

    string serverUrl;
    float timeOut;
    string responseMeesage;
    public enum Status
    {
        None,
        Sucsess,
        Error
    }
    Status status = Status.None;

    public void SendData(Dictionary<string,string> data,float settime,string seturl)
    {
        timeOut = settime;
        serverUrl = seturl;
        StartCoroutine(PostRequestSend(data));
    }

    IEnumerator  PostRequestSend(Dictionary<string, string> data)
    {
        WWWForm form = new WWWForm();
        foreach (KeyValuePair<string,string> array in data)
        {
            form.AddField(array.Key,array.Value);
        }
        WWW www = new WWW(serverUrl, form);
        yield return StartCoroutine(CheckResponse(www,timeOut));
        if(www.error != null)
        {
            status = Status.Error;
            Debug.Log(www.error);
        }

        else
        {
            status = Status.Sucsess;
            responseMeesage = www.text;
            yield return www.text;
        }
    }

    IEnumerator CheckResponse(WWW www,float time)
    {
        while(!www.isDone)
        {
            if(timeOut < 0.0f)
            {
                yield return null;
            }
            time -= Time.deltaTime;
        }
    }

    public Status GetStatus()
    {
        return status;
    }

    public string GetResPonse()
    {
        return responseMeesage;
    }
}
