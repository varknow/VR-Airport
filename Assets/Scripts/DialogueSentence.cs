using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[System.Serializable]
public class DialogueSentence
{
    [TextArea]
    public string Text;
    [TextArea(3,10)]
    public string HintText;
    [TextArea(3,10)]
    public string[] AddtionalHints;
}
