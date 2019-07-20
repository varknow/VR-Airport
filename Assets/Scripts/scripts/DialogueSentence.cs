using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
[System.Serializable]
public class DialogueSentence
{
    [TextArea]
    public string Text;

    public UnityEvent afterDialogueEvent;

    [TextArea(3,10)]
    public string HintText;
    [TextArea(3,10)]
    public string[] AddtionalHints;
}
