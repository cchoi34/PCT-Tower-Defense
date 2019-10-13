using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public string levelToLoad = "GameMap";

    public void Play () {
        SceneManager.LoadScene(levelToLoad);
    }

    public void Multiplayer () {
        Debug.Log("Coming Soon!");
    }

    public void Exit () {
        Debug.Log("Exiting Game");
        Application.Quit();
    }
}
