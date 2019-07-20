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

    //public HintSystem hintSystem;  //TODO : Singleton

    //It is optimal for the sentence and events to be the same size.
    private Queue<DialogueSentence> sentences;
    //private Queue<UnityEvent> events;

    private bool CoroutineIsBusy = false;

    private DialogueSentence currentDialogueSentence;
    private UnityEvent currentDialogueEvent;

    private UnityEvent endOfDialogueEvents;


//    public GameObject continueButton;

    internal AudioClip soundClip;


    void Start () {
        sentences = new Queue<DialogueSentence>();
        //events = new Queue<UnityEvent>();
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
        
        if (dialogue.EndOfDialogueEvents != null)
        {
            this.endOfDialogueEvents = dialogue.EndOfDialogueEvents;
        }

        if (!CoroutineIsBusy)
        {
            DisplayNextSentence();
        }
    }

    public void PerformCurrentEvent()
    {
        if (currentDialogueEvent != null)
        {
            currentDialogueEvent.Invoke();
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

        currentDialogueSentence = sentences.Dequeue();
        currentDialogueEvent = currentDialogueSentence.afterDialogueEvent;
        HintSystem.instance.SetHint(currentDialogueSentence.HintText);
        HintSystem.instance.SetAdditionalHintArray(currentDialogueSentence.AddtionalHints);

        StartCoroutine(TypeSentences(currentDialogueSentence.Text));
        PerformCurrentEvent();
    }

    public void DisplayCurrentSentence()
    {
        StartCoroutine(TypeSentences(currentDialogueSentence.Text));
    }

    //Coroutine for displaying sentences.
    private IEnumerator TypeSentences (string sentence)
    {
        if (!CoroutineIsBusy)
        {
            CoroutineIsBusy = true;
            dialogueText.text = "";
            foreach (char letter in sentence)
            {
                //display each letter with 0.01 second delay
                dialogueText.text += letter;
                yield return new WaitForSeconds(0.01f);
            }

            //AfterSoundEffect();
            CoroutineIsBusy = false;
            HumanOperator.instance.DisplayRecording();
        }
    }
    
    

    public void AfterSoundEffect()
    {
        StartCoroutine(PerformEventAfterSoundEffect(soundClip));
    }

    IEnumerator PerformEventAfterSoundEffect(AudioClip audio)
    {
        yield return new WaitForSeconds(audio.length);
        HumanOperator.instance.DisplayRecording();
    }
    //Performed after there are no more sentences.
    public void EndDialogue()
    {
        endOfDialogueEvents.Invoke();
        HumanOperator.instance.dialogueTrigger = null;
    }


}
