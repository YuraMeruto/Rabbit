using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public class ReadStage : MonoBehaviour
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

    void Start()
    {
        instancepos = pos.transform.position;
        string readdata = readDataScript.Read();
        Read(readdata);
    }

    public void Read(string readdata)
    {
        Debug.Log(readdata);
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
                if(castdata == 3)
                {
                    GameObject getobj = instanceManagerScript.GetInstanceObj(castdata);
                    Instantiate(getobj, instancepos, Quaternion.identity);
                }
                else
                {
                    GameObject backgroundobj = instanceManagerScript.GetInstanceObj(3);
                    Instantiate(backgroundobj, instancepos, Quaternion.identity);
                    GameObject getobj = instanceManagerScript.GetInstanceObj(castdata);
                    Instantiate(getobj, instancepos, Quaternion.identity);


                }
                instancepos.x+=10;
                count++;
            }
                instancepos.y-=7;
                instancepos.x = pos.transform.position.x;
        }

    }

}
