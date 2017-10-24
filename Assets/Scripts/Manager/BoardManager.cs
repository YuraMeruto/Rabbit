///////////////////////
//製作者　名越大樹
//クラス名　ボード上のオブジェクトを管理するクラス
///////////////////////

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

    /// <summary>
    ///　ボード上で動いているオブジェクトを追加する
    /// </summary>
    /// <param name="obj"></param>
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

    /// <summary>
    /// ボード上で動いているオブジェクトの確認
    /// </summary>
    /// <param name="target"></param>
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

    /// <summary>
    /// 追加するオブジェクトが既に追加されているかの確認
    /// </summary>
    bool CheckAddMoveList(GameObject obj)
    {
        for(int count = 0; count < moveList.Count; count++)
        {
            if (obj.name == moveList[count].name)//重複していないかの確認
            {
                return false;
            }
        }
        return true;
    }

}
