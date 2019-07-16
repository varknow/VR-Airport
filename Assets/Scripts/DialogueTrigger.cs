using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueTrigger : MonoBehaviour {

    public Dialogue dialogue; //The dialogue to initiate


    //Call this method when you want to initiate the dialogue related to this trigger
	public void StartDialogue () { 
        FindObjectOfType<DialogueManager>().StartDialogue(dialogue);
	}
}
