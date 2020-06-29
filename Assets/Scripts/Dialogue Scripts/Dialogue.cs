using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Creates a class that can be dragged into any object.
[System.Serializable]
public class Dialogue
{
    //Character name
    public string nameObm;

    //Dialogue text
    [TextArea(3, 10)]
    public string[] sentencesObm;
}