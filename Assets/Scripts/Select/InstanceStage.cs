//////////////////////////////
//制作者　名越大樹
//クラス名　CSVからステージを生成するクラス
//////////////////////////////

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public class InstanceStage : MonoBehaviour
{
    [SerializeField]
    ReadData readDataScript;
    [SerializeField]
    GameObject pos;
    Vector3 instancepos;
    [SerializeField]
    int lengthCount;
    int copylengthCount;
    [SerializeField]
    int sideCount;
    int copySideCount;
    [SerializeField]
    InstanceManager instanceManagerScript;
    const int width = -7;
    const int height = 10;

    void Start()
    {
        instancepos = pos.transform.position;
        string readdata = readDataScript.Read();
        Read(readdata);
    }

    public void Read(string readdata)
    {
        string[] splitdata = readdata.Split(',');
        Instance(splitdata);
    }

    void Instance(string[] data)
    {
        int count = 0;
        for (int lengthcount = 0; lengthcount < lengthCount; lengthcount++)
        {
            for (int sidecount = 0; sidecount < sideCount; sidecount++)
            {
                int castdata = int.Parse(data[count]);
                GameObject getobj = instanceManagerScript.GetInstanceObj(castdata);
                Instantiate(getobj, instancepos, Quaternion.identity);
                if (castdata != 3)
                {
                    GameObject backgroundobj = instanceManagerScript.GetInstanceObj(3);
                    Instantiate(backgroundobj, instancepos, Quaternion.identity);
                }
                instancepos.x += height;
                count++;
            }
            instancepos.y += width;
            instancepos.x = pos.transform.position.x;
        }

    }

}
