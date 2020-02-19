using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    // Loads the "Menu" scene.
    public void Title()
    {
        SceneManager.LoadScene("Menu");
    }

    // Loads the "FirstDay" scene.
    public void FirstDay()
    {
        SceneManager.LoadScene("FirstDay");
    }

    // Closes the program.
    public void Exit()
    {
        Application.Quit();
    }
}
