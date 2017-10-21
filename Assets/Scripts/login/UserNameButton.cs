

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class UserNameButton : MonoBehaviour {

    [SerializeField]
    Text nameText;
    [SerializeField]
    LoginTitle loginTitleScript;

    public void OnClick()
    {
        if(nameText.text == "")
        {
            Debug.Log("未入力です");
        }

        else
        {
            loginTitleScript.EnterLogin("",nameText.text);
        }
    }
}
