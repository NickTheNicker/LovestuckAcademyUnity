using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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

    // Character Events where false = has not seen and true = has seen.

    // Shiro Event. 
    public bool sMeet = false;

    // Lilith Events.
    public bool lMeet = false;

    // Elora Events.
    public bool eMeet = false;

}
