using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoginTitle : MonoBehaviour
{

    [SerializeField]
    string loginUrl;
    [SerializeField]
    float timeOut;
    string response;
    [SerializeField]
    WriteData writeDataScript;
    public void EnterLogin(string userid, string username)
    {
        Debug.Log(userid + username);
        Ini(userid, username);
    }

    void Ini(string userid, string username)
    {
        Dictionary<string, string> dic = new Dictionary<string, string>();
        dic.Add("id", userid);
        dic.Add("name", username);
        StartCoroutine(PostRequest(dic));
    }

    IEnumerator PostRequest(Dictionary<string, string> data)
    {
        WWWForm form = new WWWForm();
        foreach (KeyValuePair<string, string> array in data)
        {
            form.AddField(array.Key, array.Value);
        }
        WWW www = new WWW(loginUrl, form);
        yield return StartCoroutine(CheckTimeOut(www, timeOut));
        if (www.error !=null)
        {
            Debug.Log(www.error);
        }
        else
        {
            response = www.text;
            writeDataScript.Write(response,WriteData.Status.UserInfo);
        }
    }

    IEnumerator CheckTimeOut(WWW www, float timeout)
    {
        while (!www.isDone)
        {
            if (timeout < 0.0f)
            {
                Debug.Log("しばらく時間を空けてからログインをお願いします");
                yield return null;
            }
            timeout -= Time.deltaTime;
        }
    }
}
