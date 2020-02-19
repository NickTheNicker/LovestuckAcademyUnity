using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextnEvent : MonoBehaviour
{
    // Cached References.


    // Ideal display size of the for each element of the "text" array.
    [TextArea(5, 50)]

    // Array that stores text.
    public string[] text;

    // Queue for each "page" of text shown in the "TextBox".
    public Queue<string> page;

    // Start is called before the first frame update.
    void Start()
    {
        page = new Queue<string>();

    }

    public void Write()
    {
        page.Clear();

        foreach (string text in page)
        {
            page.Enqueue(text);
        }

        NextPage();
    }

    public void NextPage()
    {
        if (page.Count == 0)
        {
            
        }

        string text = page.Dequeue();
        
    }
}