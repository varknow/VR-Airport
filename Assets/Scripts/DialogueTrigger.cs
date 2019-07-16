using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueTrigger : MonoBehaviour
{

	public Text placeHolder;
    public Dialogue dialogue; //The dialogue to initiate


    //Call this method when you want to initiate the dialogue related to this trigger
	public void StartDialogue () { 
		FindObjectOfType<DialogueManager>().SetTextPlaceHolder(placeHolder);
        FindObjectOfType<DialogueManager>().StartDialogue(dialogue);
	}
}
