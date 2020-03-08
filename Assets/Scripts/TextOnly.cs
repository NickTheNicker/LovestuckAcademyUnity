using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

[Serializable]

public class TextOnly : MonoBehaviour
{
    // Cached References.
    Text iText;
    SavenSceneLoader sceneLoader;

    // Variables.

    // Page number that corresponds to an element of the "startingText" array.
    int page = 0;

    // Array for pages of text.
    [TextArea(4, 50)]
    public string[] text;


    // Displays the next page of text.
    public void NextPage()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            page += 1;
        }
    }
    // Displays text corresponding to the "page" number for elements in the text array.
    public void TextDisplay()
    {
        if (page <= text.Length)
        {
            iText.text = text[page].ToString();
        }
    }

    // Loads next scene after "1" is pressed on the last page
    public void NextScene()
    {
        if (text.Length == page + 1)
        {
            
        }
    }

    // Loads the menu scene when the "Esc" key is pressed.
    public void LoadMenu()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            sceneLoader.Menu();
        }
    }

    // Start is called before the first frame update.
    void Start()
    {
        iText = GameObject.Find("TextBoxText").GetComponent<Text>();
        sceneLoader = GameObject.Find("ScriptHolder").GetComponent<SavenSceneLoader>();
    }

    // Update is called once per frame.
    void Update()
    {
        TextDisplay();
        NextPage();
    }
}