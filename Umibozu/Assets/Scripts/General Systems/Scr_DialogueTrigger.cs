using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scr_DialogueTrigger : MonoBehaviour {

    public Scr_Dialogue dialogue;

    public void TriggerDialogue()
    {
        FindObjectOfType<Scr_DialogueManager>().StartDialogue(dialogue);
    }
}
