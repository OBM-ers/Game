using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour
{
    //Variables
    public Text nameTextObm;
    public Text dialogueTextObm;
    public Image dialogueBoxObm;
    public GameObject dialogueButtonObm;
    private Queue<string> sentencesObm;

    // Start is called before the first frame update
    void Start()
    {
        dialogueBoxObm.enabled = false;
        dialogueButtonObm.SetActive(false);
        dialogueTextObm.text = "";
        nameTextObm.text = "";
        sentencesObm = new Queue<string>();
    }

    //Starts the dialogue
    public void StartDialogueObm (Dialogue dialogueObm)
    {
        nameTextObm.text = dialogueObm.nameObm;
        sentencesObm.Clear();
        dialogueBoxObm.enabled = true;
        dialogueButtonObm.SetActive(true);

        //Puts all the sentences in the dialogue class in a queue
        foreach (string sentenceObm in dialogueObm.sentencesObm)
        {
            sentencesObm.Enqueue(sentenceObm);
        }

        DisplayNextSentenceObm();
    }

    //Displays the next sentence
    public void DisplayNextSentenceObm()
    {
        if (sentencesObm.Count == 0)
        {
            EndDialogueObm();
            return;
        }

        string sentenceObm = sentencesObm.Dequeue();
        StopAllCoroutines();
        StartCoroutine(TypeSentenceObm(sentenceObm));
    }

    //Types every single letter one by one of a sentence
    IEnumerator TypeSentenceObm (string currentSentenceObm)
    {
        dialogueTextObm.text = "";
        foreach (char letterObm in currentSentenceObm.ToCharArray())
        {
            dialogueTextObm.text += letterObm;
            yield return null;
        }
    }

    //Ends the dialogue
    void EndDialogueObm()
    {
        StopAllCoroutines();
        dialogueBoxObm.enabled = false;
        dialogueButtonObm.SetActive(false);
        dialogueTextObm.text = "";
        nameTextObm.text = "";
    }
}
