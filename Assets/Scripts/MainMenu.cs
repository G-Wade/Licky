using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void play() {
        SceneManager.LoadScene("Level_1");
    }

    public void load() {
        PlayerMovementController.fromLoad = true;
        SceneManager.LoadScene("Level_1");
    }

    public void quit() {
        Application.Quit();
    }
}
