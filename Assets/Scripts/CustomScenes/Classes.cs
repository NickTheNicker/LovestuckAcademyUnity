using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

[Serializable]

public class Classes : MonoBehaviour
{
    // Cached References.
    Text iText;
    SavenSceneLoader saveNScene;
    Save save = new Save();

    // Variables.

    // Page number that corresponds to an element of the "text" array.
    public int page = 0;

    // Array for pages of text.
    [TextArea(4, 50)]
    public string[] text;

    // Displays text corresponding to the "page" number for elements in the text array.
    public void TextDisplay()
    {
            iText.text = text[page].ToString();
    }

    // Loads a random lunch scene after 1 is pressed.
    public void LunchScene()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            saveNScene.LoadScene();
        }
    }

    // Start is called before the first frame update.
    void Start()
    {
        iText = GameObject.Find("TextBoxText").GetComponent<Text>();
        saveNScene = GameObject.Find("ScriptHolder").GetComponent<SavenSceneLoader>();

        // Sets "page" as a random interger number between 0 and the page length(inclusive).
        page = UnityEngine.Random.Range(1, text.Length+1);

        // Contains the the names of all lunch scenes.
        Dictionary<int, string>
            addScene = new Dictionary<int, string>
            {
                { 1, "LunchMeet" },
                { 2, "You" },
                { 3, "Eliza and Prisca" },
                { 4, "Fornication " },
                { 5, "Sexes? " },
                { 7, "Disappearance" },
                { 8, "The Prodigy " },
                { 9, "Uniform" }
            };

        // Updates the "lunchCount".
        save.lunchCount += 1;

        // Selects a the next lunch scene based on "lunchCount".
        saveNScene.loadName = addScene[save.lunchCount];

    }

    // Update is called once per frame.
    void Update()
    {
        TextDisplay();
        LunchScene();
    }
}