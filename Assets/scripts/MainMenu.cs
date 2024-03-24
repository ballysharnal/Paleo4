using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class MainMenu : MonoBehaviour
{

    public AudioSource audioStart;
    public AudioSource audioClic;
    public string levelToLoad;
    public void PlayGame() {
        SceneManager.LoadSceneAsync(levelToLoad);
    }

    public void QuitGame() {
        Application.Quit();
    }
}
