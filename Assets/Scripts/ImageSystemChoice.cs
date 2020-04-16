using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ImageSystemChoice : MonoBehaviour
{
    // Cached References.
    TextnEvent textnEvent;

    // Background images.
    Image back1;
    Image back2;
    Image back3;

    // Character images.
    Image girl01;
    Image girl02;
    Image girl03;

    Image girl11;
    Image girl12;

    Image girl21;
    Image girl22;

    Image girl31;
    Image girl32;

    Image girl41;
    Image girl42;

    int currentEvent;

    // Variables
    int page = 0;

    // Page numbers for when the "b"ackground image changes when "currentEvent" = 0.
    [SerializeField] int b2 = -1;
    [SerializeField] int b3 = -2;

    // Page numbers for when the "g"irl image changes when "currentEvent" = 0.
    [SerializeField] int g01 = 0;
    [SerializeField] int g02 = -1;
    [SerializeField] int g03 = -2;

    // Page numbers for when the "g"irl image changes when "currentEvent" = 1.
    [SerializeField] int g11 = -1;
    [SerializeField] int g12 = -2;

    // Page numbers for when the "g"irl image changes when "currentEvent" = 2.
    [SerializeField] int g21 = -1;
    [SerializeField] int g22 = -2;

    // Page numbers for when the "g"irl image changes when "currentEvent" = 3.
    [SerializeField] int g31 = -1;
    [SerializeField] int g32 = -2;

    // Page numbers for when the "g"irl image changes when "currentEvent" = 4.
    [SerializeField] int g41 = -1;
    [SerializeField] int g42 = -2;

    // Hides all images except "back1".
    public void StartImages()
    {
        back1.enabled = true;
        back2.enabled = false;
        back3.enabled = false;

        girl01.enabled = false;
        girl02.enabled = false;
        girl03.enabled = false;

        girl11.enabled = false;
        girl12.enabled = false;

        girl21.enabled = false;
        girl22.enabled = false;

        girl31.enabled = false;
        girl32.enabled = false;

        girl41.enabled = false;
        girl42.enabled = false;
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
        switch (currentEvent)
        {
            case 0:
                if (page == g01)
                {
                    girl01.enabled = true;
                }
                if (page == g02)
                {
                    girl01.enabled = false;
                    girl02.enabled = true;
                }

                if (page == g03)
                {
                    girl02.enabled = false;
                    girl03.enabled = true;
                }
                break;
            case 1:
                if (page == g11)
                {
                    girl11.enabled = true;
                }
                if (page == g12)
                {
                    girl11.enabled = false;
                    girl12.enabled = true;
                }
                break;
            case 2:
                if (page == g21)
                {
                    girl21.enabled = true;
                }
                if (page == g22)
                {
                    girl21.enabled = false;
                    girl22.enabled = true;
                }
                break;
            case 3:
                if (page == g31)
                {
                    girl31.enabled = true;
                }
                if (page == g32)
                {
                    girl31.enabled = false;
                    girl32.enabled = true;
                }
                break;
            case 4:
                if (page == g41)
                {
                    girl41.enabled = true;
                }
                if (page == g42)
                {
                    girl41.enabled = false;
                    girl42.enabled = true;
                }
                break;
        }
    }

    // Start is called before the first frame update.
    void Start()
    {
        StartImages();

        textnEvent = GameObject.Find("TextBoxText").GetComponent<TextnEvent>();
    }

    // Update is called once per frame.
    void Update()
    {
        // Copies the int values from the "TextnEvent" script.
        page = textnEvent.page;
        currentEvent = textnEvent.currentEvent;

        BackChange();
        GirlChange();
    }
}

