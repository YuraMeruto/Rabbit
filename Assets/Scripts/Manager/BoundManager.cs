using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoundManager : MonoBehaviour {

    [SerializeField]
    float boundForce;

    public float GetBoundForce()
    {
        return boundForce;
    }
}
