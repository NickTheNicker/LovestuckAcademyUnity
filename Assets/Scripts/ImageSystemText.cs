using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ImageSystemText : MonoBehaviour
{
    // Cached References.
    TextOnly textOnly;

    // Background images.
    Image back1;
    Image back2;
    Image back3;

    // Character images.
    Image girl1;
    Image girl2;
    Image girl3;
    Image girl4;
    Image girl5;
    Image girl6;

    // Variables
    int page = 0;

    // Page numbers for when the "b"ackground or "g"irl image changes.
    [SerializeField] int b2 = -1;
    [SerializeField] int b3 = -2;

    [SerializeField] int g2 = -1;
    [SerializeField] int g3 = -2;
    [SerializeField] int g4 = -3;
    [SerializeField] int g5 = -4;
    [SerializeField] int g6 = -5;

    // Hides all images except "back1" and "gir1".
    public void StartImages()
    {
        back1.enabled = true;
        back2.enabled = false;
        back3.enabled = false;

        girl1.enabled = true;
        girl2.enabled = false;
        girl3.enabled = false;
        girl3.enabled = false;
        girl4.enabled = false;
        girl5.enabled = false;
        girl6.enabled = false;
    }
    
    // Changes the background image accroding to the "page" int.
    public void BackChange()
    {
        if (page == b2)
        {
            back1.enabled = false;
            back2.enabled = true;
        }

        if (page == b3)
        {
            back2.enabled = false;
            back3.enabled = true;
        }
    }

    // Changes the girl image accroding to the "page" int.
    public void GirlChange()
    {
        if (page == g2)
        {
            girl1.enabled = false;
            girl2.enabled = true;
        }

        if(page == g3)
        {
            girl2.enabled = false;
            girl3.enabled = true;
        }
        if (page == g4)
        {
            girl3.enabled = false;
            girl4.enabled = true;
        }
        if (page == g5)
        {
            girl4.enabled = false;
            girl5.enabled = true;
        }
        if (page == g6)
        {
            girl5.enabled = false;
            girl6.enabled = true;
        }
    }

    // Start is called before the first frame update.
    void Start()
    {
        StartImages();
  
        textOnly = GameObject.Find("TextBoxText").GetComponent<TextOnly>();
    }

    // Update is called once per frame.
    void Update()
    {
        page = textOnly.page;
             
        BackChange();
        GirlChange();
    }
}
