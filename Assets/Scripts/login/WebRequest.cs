using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System;
using System.Collections.Specialized;
using System.Linq;
public class WebRequest : MonoBehaviour {
    string url = "http://localhost/PostTest.php";
    string userid = "0";
    string username = "hogehoge";
    string userdata = "fugafuga";
    float timeout = 5.0f;
    Dictionary<string, string> dic = new Dictionary<string, string>();
    // Use this for initialization
    void Start () {
        Request();
	}
	
    void Request()
    {

        dic.Add("id",userid);
        dic.Add("name", username);
        dic.Add("data", userdata);
        StartCoroutine(HttpPost(url,dic));
    }

    IEnumerator HttpPost(string url,Dictionary<string,string> post)
    {
        WWWForm form = new WWWForm();
        foreach(KeyValuePair<String,String> postarg in post)
        {
            form.AddField(postarg.Key,postarg.Value);
        }
        WWW www = new WWW(url, form);
        Debug.Log("終了");
        yield return StartCoroutine(CheckTimeOut(www,timeout));
        if(www.error !=null)
        {
            Debug.Log(www.error);
        }
        else
        {
            Debug.Log(www.text);
        }
    }

    IEnumerator CheckTimeOut(WWW www,float timeout)
    {
        float requestTime = Time.deltaTime;
        while(!www.isDone)
        {
            if(Time.deltaTime - requestTime < timeout)
            {
                yield return null;
            }

            else
            {
                Debug.Log("Timeout");
                break;
            }
        }
    }
}
