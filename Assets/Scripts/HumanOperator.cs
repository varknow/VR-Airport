﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HumanOperator : MonoBehaviour
{

    //edit script begin
    public GameObject RecordIcon;
    public GameObject CorrectIcon;
    public GameObject WrongIcon;

    //edit script end
    public KeyCode CorrectAnswerKey = KeyCode.T;
    public KeyCode WrongAnswerKey = KeyCode.F;
    public GameObject IconsCanvas;

    public DialogueTrigger dialogueTrigger;
    
    
    private VARKnowAgent varKnowAgent;

    // Start is called before the first frame update
    void Start()
    {
        varKnowAgent = FindObjectOfType<VARKnowAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        AnswerChecking();

        if (Input.GetKeyDown(KeyCode.D))
        {
            dialogueTrigger.StartDialogue();
        }
    }

    public void SetDialogueTrigger(DialogueTrigger trigger)
    {
        dialogueTrigger = trigger;
    }

    private void AnswerChecking()
    {
        if (Input.GetKeyDown(CorrectAnswerKey))
        {
            AnswerCommand(true);

        }

        if (Input.GetKeyDown(WrongAnswerKey))
        {
            AnswerCommand(false);
        }
    }

private void AnswerCommand(bool answer)
    {
        if (answer)
        {
            DisplayCorrectAnswer();
        }
        else
        {
            DisplayWrongAnswer();
        }
        //varKnowAgent.Disappear();
        DialogueManager.instance.DisplayNextSentence(repeat: !answer);
        DialogueManager.instance.PerformAfterEvent(repeat: !answer);
    }

    private void DisplayCorrectAnswer()
    {
        RecordIcon.SetActive(false);
        WrongIcon.SetActive(false);
        CorrectIcon.SetActive(true);

    }

    private void DisplayWrongAnswer()
    {
        CorrectIcon.SetActive(false);
        RecordIcon.SetActive(false);
        WrongIcon.SetActive(true);
    }

    public void DisplayRecording()
    {
        CorrectIcon.SetActive(false);
        WrongIcon.SetActive(false);
        RecordIcon.SetActive(true);
    }
    
    
}
