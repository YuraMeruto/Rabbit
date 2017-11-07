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
    [SerializeField]
    string userData;
    void Update()
    {
        Tap();
    }

    void Tap()
    {
        if (Input.GetMouseButtonDown(0))
        {
            string data = readDataScript.ResourcesRoadCSV(userData);
            string[] splitdata = data.Split(',');
            userInfoScript.SetValues(data);
            if (userInfoScript.GetId().Length <= 5)
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
