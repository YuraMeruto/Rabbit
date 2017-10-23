using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneManager : MonoBehaviour
{
    public enum SceneName
    {
        Titile,
        Main,
        Result,
        GameOver,
    }
    public void SceneStage(SceneName name)
    {
        switch (name)
        {
            case SceneName.Titile:
                UnityEngine.SceneManagement.SceneManager.LoadScene("Title");
                break;
            case SceneName.Main:
                UnityEngine.SceneManagement.SceneManager.LoadScene("Main");
                break;
            case SceneName.Result:
                UnityEngine.SceneManagement.SceneManager.LoadScene("Result");
                break;
            case SceneName.GameOver:
                UnityEngine.SceneManagement.SceneManager.LoadScene("GameOver");
                break;            

        }

    }

} 
