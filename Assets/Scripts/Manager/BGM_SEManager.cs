/////////////////////////
//製作者　名越大樹
//クラス名 BGM・SEを管理するクラス
/////////////////////////

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGM_SEManager : MonoBehaviour {

    [SerializeField]
    AudioClip[] seArray;
    public void PlaySE(int number,AudioSource source)
    {
        source.clip = seArray[number];
        source.Play();
    }
}
