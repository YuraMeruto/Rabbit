////////////////////////
//制作者　名越大樹
//クラス名 E15D1022
////////////////////////
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Text;
public class WriteData : MonoBehaviour {
    [SerializeField]
    string fileName;
    StreamWriter sw;
    public enum Status
    {
        None,
        UserInfo
    }
    public void Write(string data, Status status)
    {
        sw = new StreamWriter(Application.dataPath + fileName);
        Select(data,status);
        sw.Close();
    }

    void Select(string data, Status status)
    {
       switch(status)
        {
            case Status.UserInfo:
                UserInfo(data);
                break;
        }
    }

    void UserInfo(string data)
    {
        string[] datasprit = data.Split('/');
        for (int count = 1; count < datasprit.Length; count++)
        {
            sw.WriteLine(datasprit[count]);
        }
    }
}
