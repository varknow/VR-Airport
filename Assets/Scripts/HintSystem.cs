using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HintSystem : MonoBehaviour
{
    public int HintPoint;
    public Text HintPlaceHoler;
    public string CurrentHint { get; private set; }

    public string[] AdditionalHints{ get; private set; }


    private int additionalHintIndex = 0;
    // Start is called before the first frame update
    
    public void SetAdditionalHintArray(string[] hints)
    {
        AdditionalHints = hints;
    }

    public void SetHint(string hint)
    {
        CurrentHint = hint;
    }

    public string GetHint()
    {
        if (HintPoint > 0)
        {
            SubtractPoint();
            return CurrentHint;
        }
        throw new Exception("hint point is zero");
    }
    public string GetOneAdditionalHints()
    {
        if (additionalHintIndex >= AdditionalHints.Length)
        {
            additionalHintIndex = 0;
        }

        return AdditionalHints[additionalHintIndex++];
        
    }

    public void SubtractPoint()
    {
        HintPoint--;
        HintPlaceHoler.text = "Available Hints: " + HintPoint;
    }
}
