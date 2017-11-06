using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class PlayerUI : MonoBehaviour {

    [SerializeField]
    Text playerUI;
    [SerializeField]
    UIManager uiManagerScript;
    [SerializeField]
    Slider chargeGage;
    [SerializeField]
    Text remainingText;
    public void CountUpdate()
    {
        int count = GetPlayerCount();
        if (count == 0)
        {
            playerUI.text = "終了！";
        }
        else
        {
            playerUI.text = "のこり弾く回数:" + count.ToString();
        }
    }

    public void ChargeGageUpdate(float gage)
    {
        chargeGage.value = gage;
    }

    int GetPlayerCount()
    {
        return uiManagerScript.GetPlayerCount();
    }
}
