using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueTriggerOBM : MonoBehaviour
{
    public DialogueOBM dialogueObm;

    public void TriggerDialogueObm()
    {
        FindObjectOfType<DialogueManagerOBM>().StartDialogueObm(dialogueObm);
    }

    public void OnTriggerEnter2D(Collider2D playerObm)
    {
        if (playerObm.gameObject.CompareTag("Player"))
        {
            FindObjectOfType<DialogueManagerOBM>().StartDialogueObm(dialogueObm);
        }
    }
}
