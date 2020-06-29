using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueTrigger : MonoBehaviour
{
    public Dialogue dialogueObm;

    //Starts dialogue on collision trigger
    public void OnTriggerEnter2D(Collider2D playerObm)
    {
        //If collision object tag is equal to Player
        if (playerObm.gameObject.CompareTag("Player"))
        {
            FindObjectOfType<DialogueManager>().StartDialogueObm(dialogueObm);
        }
    }
}