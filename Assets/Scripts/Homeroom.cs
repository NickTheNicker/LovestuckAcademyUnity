using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

[Serializable]

public class Homeroom : MonoBehaviour
{
    // Cached References.
    Text iText;
    SavenSceneLoader saveNScene;
    Save save;




    // Array for pages of starting text that leads up to a choice event. 
    [TextArea(4, 50)]
    public string[] startingText;


    // Gives choices which diverge into separate events.
    public void Choice()
    {
            if (Input.GetKeyDown(KeyCode.Alpha1))
            {

            }
            if (Input.GetKeyDown(KeyCode.Alpha2))
            {
        
            }
            if (Input.GetKeyDown(KeyCode.Alpha3))
            {
            
            }
            if (Input.GetKeyDown(KeyCode.Alpha4))
            {
       
            }
    }

    // Displays text corresponding to the "page" number for elements in the currently used array.
    public void TextDisplay()
    {
        iText.text = startingText[0].ToString();
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
        Choice();
        LoadMenu();
    }
}
