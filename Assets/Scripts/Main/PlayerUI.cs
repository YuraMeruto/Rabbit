using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class PlayerUI : MonoBehaviour {

    [SerializeField]
    Text playerUI;
    [SerializeField]
    UIManager uiManagerScript;
    public void CountUpdate()
    {
       int count = uiManagerScript.GetPlayerCount();
        playerUI.text = "のこり弾く回数:" + count.ToString();
    }

}
