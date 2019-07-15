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

    private bool CorputinIsBusy;

    public HintSystem hintSystem;

    //It is optimal for the sentence and events to be the same size.
    private Queue<DialogueSentence> sentences;
    private Queue<UnityEvent> events;


    private DialogueSentence currentDialogueSentence;
    private UnityEvent currentDialogueEvent;

    public UnityEvent endOfDialogueEvents;


    //for making sure each sentence is finished before continuing.
    private bool isCoroutineFinished;
    public GameObject continueButton;

    internal AudioClip soundClip;


    void Start () {
        CorputinIsBusy = false;
        sentences = new Queue<DialogueSentence>();
        events = new Queue<UnityEvent>();
        instance = this;
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

        DisplayNextSentence();
        PerformAfterEvent();
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
            if(!CorputinIsBusy)
            {
                StartCoroutine(TypeSentence(currentDialogueSentence.Text));
            }
            
        }
        else
        {
            if (!CorputinIsBusy)
            {
                StartCoroutine(TypeSentence(currentDialogueSentence.Text));
            }

        }

        
        
    }

    //Coroutine for displaying sentences.
    private IEnumerator TypeSentence (string sentence)
    {
        //Deactivate the continue button for the duration
        continueButton.SetActive(false);
        CorputinIsBusy = true;
        dialogueText.text = "";
        foreach (char letter in sentence.ToCharArray())
        {
            //display each letter with 0.01 second delay
            dialogueText.text += letter;
            yield return new WaitForSeconds(0.01f); 
        }
        continueButton.SetActive(true);
        CorputinIsBusy = false;
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
        Debug.Log("End of Dialogue");
        endOfDialogueEvents.Invoke();
    }

    public void SetTextPlaceHolder(Text text1, Text text2)
    {
        dialogueText = text1;
        nameText = text2;
    }
}
