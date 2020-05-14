using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Save 
{
    // Shiro's affection points.
    public int sAffection = 0;

    // Lilith's affection points.
    public int lAffection = 0;

    // Elora's affection points.
    public int eAffection = 0;

    // The last scene the player was in.
    public string lastScene;

    // Tracks progress through lunch events.
    public int lunchCount = 0;

    // Character Events where false = has not seen and true = has seen.

    // Shiro Events. 
    public bool sMeet = false;
    public bool club1 = false;
    public bool club2 = false;

    // Lilith Events.
    public bool lMeet = false;
    public bool roof1 = false;
    public bool roof2 = false;

    // Elora Events.
    public bool eMeet = false;
    public bool library1 = false;
    public bool library2 = false;
}
