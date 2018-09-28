using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ExitButton : MonoBehaviour {

    public void loadSceneByIndex(int sceneIndex)
    {
        if (GameObject.Find("SetupObject"))
        {
            Destroy(GameObject.Find("SetupObject").gameObject);
        }
        
        SceneManager.LoadScene(sceneIndex);
    }
}
