using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoardManager : MonoBehaviour {

    [SerializeField]
    List<GameObject> moveList;
    [SerializeField]
    PlayerManager playerManagerScript;
    [SerializeField]
    BGM_SEManager bgm_seManagerScript;
    [SerializeField]
    AudioSource managerSource;
    public void AddMoveList(GameObject obj)
    {
        CheckMoveList(obj);
        moveList.Add(obj);
    }

    void ClearMoveList()
    {
        playerManagerScript.SetIsAction(true);
        moveList.Clear();
    }

    public void CheckMoveList(GameObject target)
    {
        if (moveList.Count == 0)
        {
            return;
        }
        else if (moveList.Count != 0)
        {
            for (int count = 0; count < moveList.Count; count++)
            {
                if (target.name == moveList[count].name)
                {
                    moveList.RemoveAt(count);
                }
            }
        }
        if(moveList.Count == 0)//動いているオブジェクトが全て止まり終えたときの処理
        {
            playerManagerScript.CountSubtraction();
            bgm_seManagerScript.PlaySE(0, managerSource);
            ClearMoveList();
        }
    }

    bool CheckAddMoveList(GameObject obj)
    {
        for(int count = 0; count < moveList.Count; count++)
        {
            if (obj.name == moveList[count].name)
            {
                return false;
            }
        }
        return true;
    }

}
