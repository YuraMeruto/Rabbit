using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ScoreUI : MonoBehaviour {

    [SerializeField]
    Score scoreSciript;
    [SerializeField]
    Text scoreText;

    void Start()
    {
        ScoreUpdate();
    }
    public void ScoreUpdate()
    {
        int score = scoreSciript.GetScore();
        scoreText.text = "スコア" + score.ToString();
    }
}
