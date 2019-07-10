using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HumanOperator : MonoBehaviour
{

    public KeyCode CorrectAnswerKey = KeyCode.T;
    public KeyCode WrongAnswerKey = KeyCode.F;
    public GameObject IconsCanvas;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown(CorrectAnswerKey))
        {
            DialogueManager.instance.DisplayNextSentence();
            DialogueManager.instance.PerformAfterEvent();
        }

        if (Input.GetKeyDown(WrongAnswerKey))
        {
            DialogueManager.instance.DisplayNextSentence(true);
            DialogueManager.instance.PerformAfterEvent(true);
        }
        
        
    }
}
