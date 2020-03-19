using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public class SavenSceneLoader : MonoBehaviour
{
    // Cached References.
    public Save save;

    public string sceneName;
    public bool saveExists;

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
        SceneManager.LoadScene("FirstDay");
    }

    // Loads a specified scene.
    public void LoadScene()
    {
        SceneManager.LoadScene(sceneName);
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
            file.Close();
            save = new Save();
            return;

        }
        // Gets the data from the save.
        try
        {
            save = (Save)bF.Deserialize(file);
        }
        catch
        {
            file.Close();
            ForceDeleteSaves();
            LoadFromFile();
            return;
        }
        file.Close();
    }

    public void ForceDeleteSaves()
    {
        if (File.Exists(Application.persistentDataPath + "Saves.txt"))
        {
            File.Delete(Application.persistentDataPath + "Saves.txt");
        }
    }
    // End of code written by Josh Browne and Aidan Diprose.

    public void CheckSave()
    {
        if (File.Exists(Application.persistentDataPath + "Saves.txt"))
        {
            saveExists = true;
        }
        else
        {
            saveExists = false;
        }
    }

    void Start()
    {
        // Saves the current scene you are on.
        if (SceneManager.GetActiveScene().name != "Menu")
        {
            save.lastScene = SceneManager.GetActiveScene().name;
        }

        CheckSave();
        LoadFromFile();
    }
}
