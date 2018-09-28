using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class LoadScene : MonoBehaviour
{

    public void loadSceneByIndex(int sceneIndex)
    {
        DontDestroyOnLoad(GameObject.Find("Static"));
        SceneManager.LoadScene(sceneIndex);
    }
}
