using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueTrigger : MonoBehaviour
{

    public Dialogue dialogue;

    public void TriggerDialogue()
    {
        FindObjectOfType<DialogueManager>().StartDialogue(dialogue);
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        this.TriggerDialogue();
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        FindObjectOfType<DialogueManager>().EndDialogue();
    }

}
