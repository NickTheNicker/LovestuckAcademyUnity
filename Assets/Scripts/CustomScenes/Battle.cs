using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

[Serializable]

public class Battle : MonoBehaviour
{
    // Cached References.
    Text iText;
    SavenSceneLoader saveNScene;

    // Variables.

    // Page number that corresponds to an element of the "startingText" array.
    public int page = 0;

    // Array for pages of starting text that leads up to a choice event. 
    [TextArea(4, 50)]
    public string[] battleText;

    // Arrays for pages of text for events following the choice made at the choice event.
    [TextArea(4, 50)]
    public string[] endText;

    
    // Displays text corresponding to the "page" number for elements in the currently used array.
    public void TextDisplay()
    {
    }

    // Loads next scene after "1" is pressed on the last page of an event array and adds affection points.
    public void NextScene()
    {

    }

    // Loads the menu scene when the "Esc" key is pressed.
    public void LoadMenu()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            saveNScene.Menu();
        }
    }

    // Start is called before the first frame update.
    void Start()
    {
        iText = GameObject.Find("TextBoxText").GetComponent<Text>();
        saveNScene = GameObject.Find("ScriptHolder").GetComponent<SavenSceneLoader>();
    }

    // Update is called once per frame.
    void Update()
    {
        TextDisplay();
        NextScene();
        LoadMenu();
    }
}

