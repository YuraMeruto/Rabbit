﻿///////////////////////////
//制作者　名越大樹
//クラス名 テキストからデータを取得するクラス
///////////////////////////

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Text;
public class ReadData : MonoBehaviour
{

    [SerializeField]
    string fileName;
    /// <summary>
    /// 指定されたテキストからデータを取得
    /// </summary>
    /// <returns></returns>
    public string Read()
    {
        StreamReader sr = new StreamReader(Application.dataPath + fileName, Encoding.UTF8);
        string data = sr.ReadToEnd();
        sr.Close();
        return data;
    }
}