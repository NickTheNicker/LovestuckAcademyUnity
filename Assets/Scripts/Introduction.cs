﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Introduction : MonoBehaviour
{
    // Cached References.
    // The first pages.
    GameObject canvas1;
    // The second pages.
    GameObject canvas2;
    // The sceneLoader script.
    SceneLoader sceneLoader;
    bool secondPage;

    // Start is called before the first frame update.
    void Start()
    {
        canvas1 = GameObject.Find("/Canvas1");
        canvas2 = GameObject.Find("/Canvas2");
        sceneLoader = GetComponent<SceneLoader>();
        // Hides the second pages.
        canvas2.gameObject.SetActive(false);
        // Scene starts on the first pages.
        secondPage = false;
    }


    // Update is called once per frame.
    void Update()
    {
        // Hides the first pages and opens the second pages.
        if (((Input.GetKeyDown(KeyCode.Alpha1)) || (Input.GetKeyDown(KeyCode.Alpha2))) && !secondPage)
        {
            canvas1.gameObject.SetActive(false);
            canvas2.gameObject.SetActive(true);
            secondPage = true; 
        }
        // Loads the "FirstDay" scene
        if (((Input.GetKeyDown(KeyCode.Alpha1)) || (Input.GetKeyDown(KeyCode.Alpha2))) && secondPage)
        {
            sceneLoader.FirstDay();
        }
    }
}