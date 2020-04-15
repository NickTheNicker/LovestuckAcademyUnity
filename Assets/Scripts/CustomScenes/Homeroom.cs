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
    public Save save;

    string shiro1 = "1)Talk to the person with cat ears.";
    string shiro2 = "1)Talk to Shiro";
    string lilith1 = "2)Talk to the person with ketchup on her face.";
    string lilith2 = "2)Talk to Lilith";
    string elora1 = "3)Talk to the person with a multi-gem bracelet.";
    string elora2 = "3)Talk to Elora";
    string skip = "4)Keep to yourself";

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
        if(save.lMeet)
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
        if (!save.sMeet)
        {
            saveNScene.loadName = "ShiroMeet";
        }
        
    }

    // Selects Lilith Homeroom scenes.
    public void Lilith()
    {
        if (!save.lMeet)
        {
            saveNScene.loadName = "LilithMeet";
        }
        
    }

    // Selects Elora Homeroom scenes.
    public void Elora()
    {
        if(!save.eMeet)
        {
            saveNScene.loadName = "EloraMeet";
        }
        
    }

    // Gives choices which diverge into separate events.
    public void Choice()
    {
            if (Input.GetKeyDown(KeyCode.Alpha1))
            {
            Shiro();
            saveNScene.LoadScene();
            }

            if (Input.GetKeyDown(KeyCode.Alpha2))
            {
            Lilith();
            saveNScene.LoadScene();
            }

            if (Input.GetKeyDown(KeyCode.Alpha3))
            {
            Elora();
            saveNScene.LoadScene();
            }
      
            if (Input.GetKeyDown(KeyCode.Alpha4))
            {
            // "loadName" = Random canteen scene
            saveNScene.LoadScene();
            }
    }

    // Displays text corresponding to the "page" number for elements in the currently used array.
    public void TextDisplay()
    {
        string displayedText 
            = ShiroText() + Environment.NewLine 
            + LilithText() + Environment.NewLine 
            + EloraText() + Environment.NewLine 
            + skip;
        iText.text = displayedText;
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
