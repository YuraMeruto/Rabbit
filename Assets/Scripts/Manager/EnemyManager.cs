using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour {

    [SerializeField]
    List<GameObject> enemyList;
    [SerializeField]
    BoardManager boardManagerScript;
    public void SetEnemy(GameObject set)
    {
        enemyList.Add(set);
    }

    public void RemoveEnemy(GameObject target)
    {
        for(int count =0;count < enemyList.Count;count++)
        {
            if(enemyList[count] == target)
            {
                Destroy(enemyList[count]);
                enemyList.RemoveAt(count);
            }
        }
        if(enemyList.Count == 0)
        {
            Debug.Log("全員倒しました");
        }
    }


    public void CheckMoveList(GameObject target)
    {
        boardManagerScript.CheckMoveList(target);
    }
}
