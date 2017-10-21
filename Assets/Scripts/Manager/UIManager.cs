using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour {

    [SerializeField]
    PlayerManager playerManagerScript;
    [SerializeField]
    PlayerUI playerUIScript;
    public int GetPlayerCount()
    {
        return playerManagerScript.GetPlayerCount();
    }

    public void CountUpdate()
    {
        playerUIScript.CountUpdate();
    }
}
