using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class PlayerUI : MonoBehaviour {

    [SerializeField]
    Text playerUI;
    [SerializeField]
    UIManager uiManagerScript;

    void Start()
    {
        CountUpdate();
    }

    public void CountUpdate()
    {
       int count = uiManagerScript.GetPlayerCount();
        if (count == 0)
        {
            playerUI.text = "終了！";
        }
        else
        {
            playerUI.text = "のこり弾く回数:" + count.ToString();
        }
    }

}
