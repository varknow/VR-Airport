using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;


public class DialogueTrigger : MonoBehaviour
{

	public Text dialogueText;
    public Text nameText;
    public GameObject continueButton;
    public Dialogue dialogue; //The dialogue to initiate


    //Call this method when you want to initiate the dialogue related to this trigger
	public void StartDialogue () { 
		FindObjectOfType<DialogueManager>().SetTextPlaceHolder(dialogueText, nameText);
        FindObjectOfType<DialogueManager>().StartDialogue(dialogue);
        FindObjectOfType<DialogueManager>().continueButton = continueButton;

    }
}
