using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class ChangeLevel : MonoBehaviour
{
    public string sceneToLoad;
    public void SwitchToEnd() {
        SceneManager.LoadSceneAsync(sceneToLoad);
    }
}
