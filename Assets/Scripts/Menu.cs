using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    SavenSceneLoader saveNScene;
    Save save;

    // Start is called before the first frame update
    void Start()
    {
        saveNScene = GameObject.Find("ScriptHolder").GetComponent<SavenSceneLoader>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            SceneManager.LoadScene("Introduction");
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            SceneManager.LoadScene(save.lastScene);
        }
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            saveNScene.Exit();
        }

    }
}

