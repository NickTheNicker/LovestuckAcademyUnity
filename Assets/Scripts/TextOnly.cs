﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

[Serializable]

public class TextOnly : MonoBehaviour
{
    // Cached References.
    Text iText;
    SavenSceneLoader saveNScene;
    Save save = new Save();


    // Variables.

    // Character you talk to in the scene, 1 = "Shiro" 2 = "Lilith" 3 = "Elora".
    [SerializeField] int character = 0;

    // Amounts of affection points rewarded to a character for finishing the event,
    [SerializeField] int affectionChange = 0;

    // Page number that corresponds to an element of the "text" array.
    public int page = 0;

    // Array for pages of text.
    [TextArea(4, 50)]
    public string[] text;


    // Displays the next page of text.
    public void NextPage()
    {
        if (Input.GetKeyDown(KeyCode.Space))
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

    // Increases affection points at the start.
    public void AffectionChange()
    {
        switch (character)
        {
            // Shiro
            case 1: save.sAffection += affectionChange; break;
            // Lilith
            case 2: save.lAffection += affectionChange; break;
            // Elora
            case 3: save.eAffection += affectionChange; break;
        }
    }

    // Loads next scene on the last page and adds affection points.
    public void NextScene()
    {
        if (text.Length == page)
        {
            AffectionChange();
            saveNScene.LoadScene();
        }
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
        NextPage();
        NextScene();
        LoadMenu();
    }
}