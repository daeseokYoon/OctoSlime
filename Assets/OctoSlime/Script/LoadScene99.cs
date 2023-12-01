using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadScene99 : MonoBehaviour
{
    public string Scene;

    private void Awake()
    {
        Screen.SetResolution(600, 2020, true);
    }

    public void LoadScene()
    {
        SceneManager.LoadScene(Scene);
    }
}
