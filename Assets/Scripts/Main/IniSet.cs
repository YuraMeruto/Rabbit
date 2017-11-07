/////////////////////////
//製作者　名越大樹
//最初だけ
//////////////////////////

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IniSet : MonoBehaviour {

    [SerializeField]
    UIManager UiManagerScript;
    [SerializeField]
    InstanceStage instanceStageScript;
    [SerializeField]
    PlayerManager playerManagerScript;
    [SerializeField]
    GameMaster gameMasterScript;
    public void Ini()
    {        
        instanceStageScript.Ini();
        playerManagerScript.Ini(instanceStageScript.GetPlayerObj());
        UiManagerScript.Ini();
        gameMasterScript.SetIsGamePlay(true);
        Destroy(gameObject);
    }
}
