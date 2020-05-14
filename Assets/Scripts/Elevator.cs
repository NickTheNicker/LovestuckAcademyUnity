using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

[Serializable]

public class Elevator : MonoBehaviour
{
    // Cached References.
    Text iText;
    SavenSceneLoader saveNScene;
    public Save save;

    // When false = Transition text, when true = choice event.
    private bool choice = false;

    string skip = "1)Go home";
    string shiro1 = "(Talk to the person with cat ears to unlock)";
    string shiro2 = "2)Go to the anime club ";
    string lilith1 = "(Talk to the person with ketchup on her face to unlock)";
    string lilith2 = "3)Go to the rooftop ";
    string elora1 = "(Talk to the person with a multi-gem bracelet to unlock)";
    string elora2 = "4)Go to the library ";
    
    // Changes choice from false to true when space is pressed.
    public void Space()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            choice = true;
        }
    }
    

    // Methods that change text based on bools in "Save".
    private string ShiroText()
    {
        if (save.sMeet)
        {
            return shiro2;
        }
        else
        {
            return shiro1;
        }
    }
    private string LilithText()
    {
        if (save.lMeet)
        {
            return lilith2;
        }
        else
        {
            return lilith1;
        }
    }
    private string EloraText()
    {
        if (save.eMeet)
        {
            return elora2;
        }
        else
        {
            return elora1;
        }
    }

    // Selects Shiro Homeroom scenes.
    public void Shiro()
    {
        if (save.sMeet)
        {
            if (!save.club1)
            {
                saveNScene.loadName = "Club1st";
            }
            else if ((!save.club2) && (save.sAffection >= 16))
            {
                saveNScene.loadName = "Club2nd";
            }
            else saveNScene.loadName = "ClubFill";
        }
    }

    // Selects Lilith Homeroom scenes.
    public void Lilith()
    {
        if (save.lMeet)
        {
            if (!save.roof1)
            {
                saveNScene.loadName = "Roof1st";
            }
            else if ((!save.roof2) && (save.lAffection >= 16))
            {
                saveNScene.loadName = "Roof2nd";
            }
            else saveNScene.loadName = "RoofFill";
        }
    }

    // Selects Elora Homeroom scenes.
    public void Elora()
    {
        if (save.eMeet)
        {
            if (!save.library1)
            {
                saveNScene.loadName = "Library1st";
            }
            else if ((!save.library2) && (save.eAffection >= 16))
            {
                saveNScene.loadName = "Library2nd";
            }
            else saveNScene.loadName = "LibraryFill";
        }
    }

    // Gives choices which diverge into separate events.
    public void Choice()
    {
        // Only functions when choice is true.
        if (choice)
        { 
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            saveNScene.loadName = "Home";
            saveNScene.LoadScene();
        }

        if ((Input.GetKeyDown(KeyCode.Alpha2)) && (save.sMeet))
        {
            Shiro();
            saveNScene.LoadScene();
        }

        if ((Input.GetKeyDown(KeyCode.Alpha3)) && (save.lMeet))
        {
            Lilith();
            saveNScene.LoadScene();
        }

        if ((Input.GetKeyDown(KeyCode.Alpha4)) && (save.eMeet))
        {
            Elora();
            saveNScene.LoadScene();
        }
        }
    }

    // Displays text corresponding to the "page" number for elements in the currently used array.
    public void TextDisplay()
    {
        string displayedText2
            = skip + Environment.NewLine 
            + ShiroText() + Environment.NewLine
            + LilithText() + Environment.NewLine
            + EloraText();

        if (choice)
        {
            iText.text = displayedText2;
        }
        else iText.text = "You finish lunch and the rest of your classes.";
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
        Space();
        TextDisplay();
        Choice();
        LoadMenu();
    }
}

