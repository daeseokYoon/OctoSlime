using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChange99 : MonoBehaviour
{
    public string sceneName;
    //씬 불러오는 함수 Load
    public void Load()
    {
        SceneManager.LoadScene(sceneName);
        Time.timeScale = 1.0f;
    }
}
