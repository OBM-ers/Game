using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class DialogueOBM
{
    public string nameObm;

    [TextArea(3, 10)]
    public string[] sentencesObm;
}
