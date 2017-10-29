using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstanceManager : MonoBehaviour {

    [SerializeField]
    GameObject[] instanceObjects;

    public GameObject GetInstanceObj(int number)
    {
        return instanceObjects[number];
    }

}
