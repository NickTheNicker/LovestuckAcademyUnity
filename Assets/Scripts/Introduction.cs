using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Introduction : MonoBehaviour
{
    // Cached References.
    // The first page.
    GameObject canvas1;
    // The second page.
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
        // Hides the second page.
        canvas2.gameObject.SetActive(false);
        // Scene starts on the first page.
        secondPage = false;
    }


    // Update is called once per frame.
    void Update()
    {
        // Hides the first page and opens the second page.
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
