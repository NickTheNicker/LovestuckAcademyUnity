using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;


public class AffectionDisplay : MonoBehaviour
{
    // Cached References.
    Text iText;
    SavenSceneLoader saveNScene;
    public Save save;

    public void AffectionText()
    {
        string text = "Character Affection" + Environment.NewLine + Environment.NewLine +
            "Shiro " + save.sAffection + " Affection points" + Environment.NewLine + Environment.NewLine +
            "Lilith " + save.lAffection + " Affection points" + Environment.NewLine + Environment.NewLine +
            "Elora  " + save.eAffection + " Affection points";
        iText.text = text;
    }

    // Start is called before the first frame update
    void Start()
    {
        iText = GameObject.Find("TextBoxText").GetComponent<Text>();
        saveNScene = GameObject.Find("ScriptHolder").GetComponent<SavenSceneLoader>();
    }

    // Update is called once per frame
    void Update()
    {
        AffectionText();
    }
}
