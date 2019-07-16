using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[System.Serializable]
public class Dialogue {

    public string name;

  
    public DialogueSentence[] sentences;

    public UnityEvent[] AfterDialogueEvents;
    public UnityEvent EndOfDialogueEvents;
    
    

}
