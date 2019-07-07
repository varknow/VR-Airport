using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class DialogueManager : MonoBehaviour {

    #region Singleton
    public static DialogueManager instance;

    private void Awake()
    {
        instance = this;
    }
    #endregion

    public Text nameText;
    public Text dialogueText;
    

    //It is optimal for the sentence and events to be the same size.
    private Queue<string> sentences;
    private Queue<UnityEvent> events;

    public UnityEvent endOfDialogueEvents;


    //for making sure each sentence is finished before continuing.
    private bool isCoroutineFinished;
    public GameObject continueButton;


    void Start () {
        sentences = new Queue<string>();
        events = new Queue<UnityEvent>();
	}

    //called by DialogueTrigger
    public void StartDialogue(Dialogue dialogue)
    {
        Debug.Log("Starting Conversation with " + dialogue.name);

        nameText.text = dialogue.name;

        sentences.Clear();

        foreach (string sentence in dialogue.sentences)
        {
            sentences.Enqueue(sentence);
        }

        foreach (UnityEvent afterEvent in dialogue.AfterDialogueEvents)
        {
            events.Enqueue(afterEvent);
        }

        DisplayNextSentence();
        PerformAfterEvent();
    }


    //Pop the event queue
    public void PerformAfterEvent()
    {
        if (events.Count == 0)
        {
            Debug.LogWarning("Event Queue emptied");
            return;
        }

        UnityEvent afterEvent = events.Dequeue();

        if(afterEvent != null)
        {
            afterEvent.Invoke();
        }
    }


    //Pop the sentence queue
    public void DisplayNextSentence()
    {
        if(sentences.Count == 0)
        {
            EndDialogue();
            return;
        }

        string sentence = sentences.Dequeue();

        StartCoroutine(TypeSentence(sentence));



    }

    //Coroutine for displaying sentences.
    private IEnumerator TypeSentence (string sentence)
    {
        dialogueText.text = "";
        foreach (char letter in sentence.ToCharArray())
        {
            //display each letter with 0.01 second delay
            dialogueText.text += letter;
            yield return new WaitForSeconds(0.01f); 
        }
        continueButton.SetActive(true);
    }


    //Performed after there are no more sentences.
    public void EndDialogue()
    {
        Debug.Log("End of Dialogue");
        endOfDialogueEvents.Invoke();
    }
}
