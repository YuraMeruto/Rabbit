using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoardManager : MonoBehaviour {

    [SerializeField]
    List<GameObject> moveList;
    [SerializeField]
    PlayerManager playerManagerScript;
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
        if(moveList.Count == 0)
        {
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
