using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhaseManager : MonoBehaviour {

    [SerializeField]
    bool isGamePlay;

    public bool GetIsGamePlay()
    {
        return isGamePlay;
    }

    public void SetISGamePlay(bool set)
    {
        isGamePlay = set;
    }

}
