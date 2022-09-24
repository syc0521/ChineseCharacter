using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Loading : Singleton<Loading>
{
    private bool loadable;

    private void Start() 
    {
        loadable=true;
    }

    public void LoadScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }

    public void LoadScene(int sceneID)
    {
        SceneManager.LoadScene(sceneID);
    }

    public void LoadNextScene()
    {
        if(SceneManager.GetActiveScene().buildIndex==4) SceneManager.LoadScene(1);
        else SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex+1);
    }

    public void LoadCurrentScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
