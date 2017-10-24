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
