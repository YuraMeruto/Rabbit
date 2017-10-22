using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreManager : MonoBehaviour {

    [SerializeField]
    Score scoreScript;
    [SerializeField]
    UIManager uiManagerScript;
    public void AddScore(int value)
    {
        scoreScript.AddScore(value);
        uiManagerScript.ScoreUpdate();
    }
}
