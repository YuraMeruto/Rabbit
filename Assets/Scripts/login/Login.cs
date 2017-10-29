using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Login : MonoBehaviour
{
    [SerializeField]
    GameObject inputFiled;
    [SerializeField]
    GameObject buttonObj;
    [SerializeField]
    ReadData readDataScript;
    [SerializeField]
    UserInfo userInfoScript;
    [SerializeField]
    LoginTitle loginTitleScript;

    void Update()
    {
        Tap();
    }

    void Tap()
    {
        if (Input.GetMouseButtonDown(0))
        {
            string data = readDataScript.Read();
            userInfoScript.SetValues(data);
            if (userInfoScript.GetId() == "1")
            {
                inputFiled.SetActive(true);
                buttonObj.SetActive(true);
            }
            else
            {
                loginTitleScript.EnterLogin(userInfoScript.GetId(), userInfoScript.GetName());
            }
        }
    }
}
