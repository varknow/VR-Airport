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

    private Text nameText;
    private Text dialogueText;

    public HintSystem hintSystem;  //TODO : Singleton

    //It is optimal for the sentence and events to be the same size.
    private Queue<DialogueSentence> sentences;
    private Queue<UnityEvent> events;

    private bool CoroutineIsBusy = false;

    private DialogueSentence currentDialogueSentence;
    private UnityEvent currentDialogueEvent;

    public UnityEvent endOfDialogueEvents;


//    public GameObject continueButton;

    internal AudioClip soundClip;


    void Start () {
        sentences = new Queue<DialogueSentence>();
        events = new Queue<UnityEvent>();
        instance = this;
	}

    public void SetTextPlaceHolder(Text dialogueText, Text nameText)
    {
        this.dialogueText = dialogueText;
        if (nameText != null) this.nameText = nameText;
    }

    //called by DialogueTrigger
    public void StartDialogue(Dialogue dialogue)
    {
        
        Debug.Log("Starting Conversation with " + dialogue.name);

        nameText.text = dialogue.name;

        sentences.Clear();

        foreach (var sentence in dialogue.sentences)
        {
            sentences.Enqueue(sentence);
        }

        foreach (UnityEvent afterEvent in dialogue.AfterDialogueEvents)
        {
            events.Enqueue(afterEvent);
        }

        
        if (dialogue.EndOfDialogueEvents != null)
        {
            this.endOfDialogueEvents = dialogue.EndOfDialogueEvents;
        }
        if (!CoroutineIsBusy)
        {
            DisplayNextSentence();
            PerformAfterEvent();

        }
    }


    //Pop the event queue
    public void PerformAfterEvent(bool repeat = false)
    {
        if (events.Count == 0 && !repeat)
        {
            Debug.LogWarning("Event Queue emptied");
           return;
        }


        if (!repeat)
        {
            currentDialogueEvent = events.Dequeue();
            if(currentDialogueEvent != null)
            {
                currentDialogueEvent.Invoke();
            }
        }
        
        else
        {
            
            if(currentDialogueEvent != null)
            {
                currentDialogueEvent.Invoke();
            }

        }
        
    }


    //Pop the sentence queue
    public void DisplayNextSentence(bool repeat = false)
    {
        if(sentences.Count == 0 && !repeat)
        {
            EndDialogue();
            return;
        }

        if (!repeat)
        {
            currentDialogueSentence = sentences.Dequeue();
            hintSystem.SetHint(currentDialogueSentence.HintText);
            hintSystem.SetAdditionalHintArray(currentDialogueSentence.AddtionalHints);
            if (!CoroutineIsBusy)
            {
                StartCoroutine(TypeSentences(currentDialogueSentence.Text));

            }
        }
        else
        {
            if (!CoroutineIsBusy)
            {
                StartCoroutine(TypeSentences(currentDialogueSentence.Text));

            }
        }

        
        
    }

    //Coroutine for displaying sentences.
    private IEnumerator TypeSentences (string sentence)
    {
        CoroutineIsBusy = true;
        dialogueText.text = "";
        foreach (char letter in sentence)
        {
            //display each letter with 0.01 second delay
            dialogueText.text += letter;
//            yield return null;
            yield return new WaitForSeconds(0.01f);
        }


        //        AfterSoundEffect();
        CoroutineIsBusy = false;
        FindObjectOfType<HumanOperator>().DisplayRecording();
    }
    
    

    public void AfterSoundEffect()
    {
        StartCoroutine(PerformEventAfterSoundEffect(soundClip));
    }

    IEnumerator PerformEventAfterSoundEffect(AudioClip audio)
    {
        yield return new WaitForSeconds(audio.length);
        FindObjectOfType<HumanOperator>().DisplayRecording();
    }
    //Performed after there are no more sentences.
    public void EndDialogue()
    {
        endOfDialogueEvents.Invoke();
    }


}
