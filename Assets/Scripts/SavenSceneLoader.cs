using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public class SavenSceneLoader : MonoBehaviour
{
    // Cached References.
    Save save;

    // Loads the "Menu" scene.
    public void Menu()
    {
        // Saves progress.
        SaveToFile();
        SceneManager.LoadScene("Menu");
    }

    // Loads the "FirstDay" scene.
    public void FirstDay()
    {
        SaveToFile();
        SceneManager.LoadScene("FirstDay");
    }

    // Closes the program.
    public void Exit()
    {
        Application.Quit();
    }

    // Save system from Josh Browne and Aidan Diprose. 
    public void SaveToFile()
    {
        BinaryFormatter bF = new BinaryFormatter();
        FileStream file;
        // Makes sure the file to save to exists.
        if (File.Exists(Application.persistentDataPath + "Saves.txt"))
        {
            file = File.Open(Application.persistentDataPath + "Saves.txt", FileMode.Open);
        }
        // Creates a new save file.
        else
        {
            file = File.Create(Application.persistentDataPath + "Saves.txt");
        }
        bF.Serialize(file, save);
        file.Close();
    }

    public void LoadFromFile()
    {
        BinaryFormatter bF = new BinaryFormatter();
        FileStream file;
        // Makes sure the save file exists.
        if (File.Exists(Application.persistentDataPath + "Saves.txt"))
        {
            file = File.Open(Application.persistentDataPath + "Saves.txt", FileMode.Open);
        }
        else
        {
            file = File.Create(Application.persistentDataPath + "Saves.txt");
            Save tempSaves = new Save();
            bF.Serialize(file, tempSaves);
        }
        // Gets the data from the save.
        save = (Save)bF.Deserialize(file);
        file.Close();
    }
    // End of code written by Josh Browne and Aidan Diprose.

    public void DeleteFile()
    {
       // To be done 
    }
    void Start()
    {
        // Saves the current scene.
        if (SceneManager.GetActiveScene().name != "Menu")
        {
            save.lastScene = SceneManager.GetActiveScene().name;
        }
        LoadFromFile();
    }
}
