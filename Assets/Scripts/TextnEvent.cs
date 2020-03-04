using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

[Serializable]

public class TextnEvent : MonoBehaviour
{
    // Cached References.
    Text iText;
    SceneLoader sceneLoader;
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

    // Starts a choice event when the page number reaches a desired point.
    [SerializeField] int choiceTrigger = 0;

    // The number of choices available.
    [SerializeField] int choices = 2;

    // Character you talk to in the scene, 1 = "Shiro" 2 = "Lilith" 3 = "Elora".
    [SerializeField] int character = 0;

    // Amounts of affection points added for choosing each event.
    [SerializeField] int affectionChange1 = 0;
    [SerializeField] int affectionChange2 = 0;
    [SerializeField] int affectionChange3 = 0;
    [SerializeField] int affectionChange4 = 0;


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
        if ((Input.GetKeyDown(KeyCode.Alpha1) && (!choice || chosen) ))
        {
            page += 1;
        }  
    }

    // Gives choices which diverge into separate events.
    public void Choice()
    {
        if ((page == choiceTrigger && !chosen))
        {
            // Temporarily disables "NextPage()".
            choice = true;

            if (Input.GetKeyDown(KeyCode.Alpha1))
            {
                currentEvent = 1;
                page = 0;
                // Enables "NextPage()".
                chosen = true;
            }
            if (Input.GetKeyDown(KeyCode.Alpha2))
            {
                currentEvent = 2;
                page = 0;
                chosen = true;
            }
            if ((Input.GetKeyDown(KeyCode.Alpha3) && choices >= 3))
            {
                currentEvent = 3;
                page = 0;
                chosen = true;
            }
            if ((Input.GetKeyDown(KeyCode.Alpha4) && choices == 4 ))
            {
                currentEvent = 4;
                page = 0;
                chosen = true;
            }
        }
    }

    // Increases or decreases affection points based on the character and event selected;
    public void AffectionChange()
    {
       switch (character)
        {
            // Shiro
            case 1:
switch (currentEvent)
                {
                    case 1:
                        save.sAffection += affectionChange1;
                        break;
                    case 2:
                        save.sAffection += affectionChange2;
                        break;
                    case 3:
                        save.sAffection += affectionChange3;
                        break;
                    case 4:
                        save.sAffection += affectionChange4;
                        break;
                }
                break;
                // Lilith
            case 2:
                switch (currentEvent)
                {
                    case 1:
                        save.lAffection += affectionChange1;
                        break;
                    case 2:
                        save.lAffection += affectionChange2;
                        break;
                    case 3:
                        save.lAffection += affectionChange3;
                        break;
                    case 4:
                        save.lAffection += affectionChange4;
                        break;
                }
                break;
                // Elora
            case 3:
                switch (currentEvent)
                {
                    case 1:
                        save.eAffection += affectionChange1;
                        break;
                    case 2:
                        save.eAffection += affectionChange2;
                        break;
                    case 3:
                        save.eAffection += affectionChange3;
                        break;
                    case 4:
                        save.eAffection += affectionChange4;
                        break;
                }
                break;
        }
    }

    // Displays text corresponding to the "page" number for elements in the currently used array.
    public void TextDisplay()
    {
        if (currentEvent == 0)
        {
            iText.text = startingText[page].ToString();
        }
        // "page <= event1Text.Length" prevents "index was outside of bounds of array" error
        if ((currentEvent == 1 && page <= event1Text.Length))
        {
            iText.text = event1Text[page].ToString();
        }
        if ((currentEvent == 2 && page <= event2Text.Length))
        {
            iText.text = event2Text[page].ToString();
        }
        if ((currentEvent == 3 && page <= event3Text.Length))
        {
            iText.text = event3Text[page].ToString();
        }
        if ((currentEvent == 4 && page <= event4Text.Length))
        {
            iText.text = event4Text[page].ToString();
        }
    }

    // Loads next scene after "1" is pressed on the last page of an event array.
    public void NextScene()
    {
        if ((
            (event1Text.Length == page + 1 && currentEvent == 1) ||
            (event2Text.Length == page + 1 && currentEvent == 2) ||
            (event3Text.Length == page + 1 && currentEvent == 3) ||
            (event4Text.Length == page + 1 && currentEvent == 4)
           ))
        {

        }
    }


    // Start is called before the first frame update.
    void Start()
    {
        iText = GameObject.Find("TextBoxText").GetComponent<Text>();
        sceneLoader = GameObject.Find("ScriptHolder").GetComponent<SceneLoader>();
        save = GameObject.Find("ScriptHolder").GetComponent<Save>();
    }

    // Update is called once per frame.
    void Update()
    {
        TextDisplay();
        NextPage();
        Choice();
    }
}
