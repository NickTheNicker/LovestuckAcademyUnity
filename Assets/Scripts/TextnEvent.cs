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


    // Start is called before the first frame update.
    void Start()
    {
        iText = GameObject.Find("TextBoxText").GetComponent<Text>();
    }

    // Displays the next page of text.
    public void NextPage()
    {
        if ((Input.GetKeyDown(KeyCode.Alpha1) && (!choice || chosen) ))
        {
            page += 1;
        }  
    }

    // Disables "NextPage()" and gives numbered choices which diverge into separate events.
    public void Choice()
    {
        if ((page == choiceTrigger && !chosen))
        {
            // Disables "NextPage()".
            choice = true;

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

    // Update is called once per frame.
    void Update()
    {
        TextDisplay();
        NextPage();
        Choice();
    }
}
