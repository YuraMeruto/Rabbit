using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UserInfo : MonoBehaviour
{

    string userid;
    string username;
    int logincount;

    public void SetValues(string data)
    {
        string[] datasprit = data.Split(',');
            userid = datasprit[0];
            username = datasprit[1];
    }

    public string GetId()
    {
        return userid;
    }

    public string GetName()
    {
        return username;
    }

}
