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
    public string lastScene = "Introduction";

    // Tracks progress through lunch events.
    public int lunchCount = 0;

    // Character Events where false = has not seen and true = has seen.

    // Shiro Event. 
    public bool sMeet = false;

    // Lilith Events.
    public bool lMeet = false;

    // Elora Events.
    public bool eMeet = false;

}
