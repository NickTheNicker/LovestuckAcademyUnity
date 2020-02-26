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
    
    // Page number that corresponds to an element of the "pages" array.
    int page = 0;

    // Bool for when in a multiple choice event.
    bool choice = false;

    // Starts a choice event when the page number reaches a desired point.
    int trigger = 0;

    int choices = 2;

    // String array that stores each page of text displayed on the text box.
    [TextArea(4, 50)]
    public string []pages;

 

    // Start is called before the first frame update.
    void Start()
    {
        iText = GameObject.Find("TextBoxText").GetComponent<Text>();
    }

    // Displays the next page of text.
    public void NextPage()
    {
        if ((Input.GetKeyDown(KeyCode.Alpha1) && !choice))
        {
            page += 1;
        }  
    }

    // Disables "NextPage()" and gives numbered choices which diverge into separate events.
    public void Choice()
    {
        if (page == trigger)
        {
            choice = true;
            if (Input.GetKeyDown(KeyCode.Alpha1))
            {

            }
            if (Input.GetKeyDown(KeyCode.Alpha2))
            {

            }
            if ((Input.GetKeyDown(KeyCode.Alpha3) && choices >= 3))
            {

            }
            if ((Input.GetKeyDown(KeyCode.Alpha4) && choices == 4 ))
            {

            }

        }

    }


    // Update is called once per frame.
    void Update()
    {
        // Displays text corresponding to the "page" number for elements in the "pages" array.
        iText.text = pages[page].ToString();

        NextPage();


    }
}
