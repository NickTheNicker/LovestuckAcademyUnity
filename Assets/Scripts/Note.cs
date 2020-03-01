using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Note : MonoBehaviour
{
    [SerializeField] Arrays[] arrays;

}

[System.Serializable]
public class Arrays
{
    public string name;
    public string[] sentences;
    public int level;

}