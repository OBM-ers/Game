using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;
using UnityEngine.UI;

public class DialogueManagerOBM : MonoBehaviour
{
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

    public void StartDialogueObm (DialogueOBM dialogueObm)
    {
        nameTextObm.text = dialogueObm.nameObm;
        sentencesObm.Clear();
        dialogueBoxObm.enabled = true;
        dialogueButtonObm.SetActive(true);

        foreach (string sentenceObm in dialogueObm.sentencesObm)
        {
            sentencesObm.Enqueue(sentenceObm);
        }

        DisplayNextSentenceObm();
    }

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

    IEnumerator TypeSentenceObm (string currentSentenceObm)
    {
        dialogueTextObm.text = "";
        foreach (char letterObm in currentSentenceObm.ToCharArray())
        {
            dialogueTextObm.text += letterObm;
            yield return null;
        }
    }

    void EndDialogueObm()
    {
        StopAllCoroutines();
        dialogueBoxObm.enabled = false;
        dialogueButtonObm.SetActive(false);
        dialogueTextObm.text = "";
        nameTextObm.text = "";
    }
}
