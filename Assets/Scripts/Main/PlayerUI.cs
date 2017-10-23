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

    public void ChargeGageUpdate(float gage)
    {
        chargeGage.value = gage;
    }
}
