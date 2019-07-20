using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueTrigger : MonoBehaviour
{

	public Text dialogueText;
    public Text nameText;
    public Dialogue dialogue; //The dialogue to initiate


    //Call this method when you want to initiate the dialogue related to this trigger
	public void StartDialogue () { 
		DialogueManager.instance.SetTextPlaceHolder(dialogueText,nameText);
        DialogueManager.instance.StartDialogue(dialogue);
	}
}
