﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

[Serializable]

public class FirstDay : MonoBehaviour
{
    // Cached References.
    Text iText;
    SavenSceneLoader saveNScene;
    Save save;

    // Variables.

    // Page number that corresponds to an element of the "startingText" array.
    int page = 0;

    // 0="startingText" 1="event1Text" 2="event2Text" 3="event3Text" 4="event4Text".
    int currentEvent = 0;

    // Bool for when in a multiple choice event.
    bool choice = false;

    // Bool for if a choice has been made in the choice event.
    bool chosen = false;

    // Array for pages of starting text that leads up to a choice event. 
    [TextArea(4, 50)]
    public string[] startingText;

    // Arrays for pages of text for events following the choice made at the choice event.
    [TextArea(4, 50)]
    public string[] event1Text;
    [TextArea(4, 50)]
    public string[] event2Text;
    [TextArea(4, 50)]
    public string[] event3Text;
    [TextArea(4, 50)]
    public string[] event4Text;

    // Displays the next page of text.
    public void NextPage()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            page += 1;
        }

        // Required for the choice system to function.
        if ((Input.GetKeyDown(KeyCode.Alpha2)) && (startingText.Length-1 == page) && (!chosen))
        {
            page += 1;
        }

        if ((Input.GetKeyDown(KeyCode.Alpha3)) && (startingText.Length - 1 == page) && (!chosen))
        {
            page += 1;
        }

        if ((Input.GetKeyDown(KeyCode.Alpha4)) && (startingText.Length - 1 == page) && (!chosen))
        {
            page += 1;
        }
    }

    // Gives choices which diverge into separate events and increases affection points.
    public void Choice()
    {
        if ((page == startingText.Length) && (!chosen))
        {
             if (Input.GetKeyDown(KeyCode.Alpha1))
            {
                currentEvent = 1;
                page = 0;
                chosen = true;
           
            }
            if (Input.GetKeyDown(KeyCode.Alpha2))
            {
                currentEvent = 2;
                page = 0;
                chosen = true;
                save.lAffection += 2;
            }
            if (Input.GetKeyDown(KeyCode.Alpha3))
            {
                currentEvent = 3;
                page = 0;
                chosen = true;
                save.eAffection += 2;
            }
            if (Input.GetKeyDown(KeyCode.Alpha4)) 
            {
                currentEvent = 4;
                page = 0;
                chosen = true;
                save.sAffection += 2;
            }
        }     
    }

    // Displays text corresponding to the "page" number for elements in the currently used array.
    public void TextDisplay()
    {
        if (currentEvent == 0)
        {
            iText.text = startingText[page].ToString();
        }
        if (currentEvent == 1) 
        {
            iText.text = event1Text[page].ToString();
        }
        if (currentEvent == 2) 
        {
            iText.text = event2Text[page].ToString();
        }
        if (currentEvent == 3) 
        {
            iText.text = event3Text[page].ToString();
        }
        if (currentEvent == 4)
        {
            iText.text = event4Text[page].ToString();
        }
    }

    // Loads next scene after "1" is pressed on the last page of an event array.
    public void NextScene()
    {
        if ((
            (event1Text.Length == page + 1) && (currentEvent == 1) ||
            (event2Text.Length == page + 1) && (currentEvent == 2) ||
            (event3Text.Length == page + 1) && (currentEvent == 3) ||
            (event4Text.Length == page + 1) && (currentEvent == 4)
           ))
        {
            // When "Loadscene()" is carried out the scene loaded is "Homeroom".
            saveNScene.sceneName = "Homeroom";
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
        Choice();
        LoadMenu();
    }
}