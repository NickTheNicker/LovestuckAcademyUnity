using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextnEvent : MonoBehaviour
{
    public Text displayedText;

    // Queue for each "page" of text shown in the "TextBox".
    public Queue<string> pages;

    // Start is called before the first frame update.
    void Start()
    {
        pages = new Queue<string>();
    }

    public void Write()
    {
        Debug.Log("first page");
        pages.Clear();

        foreach (string text in pages)
        {
            pages.Enqueue(text);
        }

        NextPage();
    }

    public void NextPage()
    {
        string text = pages.Dequeue();
        displayedText.text = Text.text;
    }
}