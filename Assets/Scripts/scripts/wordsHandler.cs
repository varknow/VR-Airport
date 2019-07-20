using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class wordsHandler : MonoBehaviour
{
    public string[] words;
    public static bool nxtWord=false;
    public static string curWord;
    private int cntr = 0;
    Text text;
    // Start is called before the first frame update
    void Start()
    {
        text = GetComponentInChildren<Text>();
        curWord = words[levelManager.levelCntr];
        text.color = Color.white;
        text.enabled = true;
        text.text = curWord;
    }

    // Update is called once per frame
    void Update()
    {
        if (nxtWord)
        {
            nxtWord = false;
            cntr++;
            if (cntr < words.Length)
            {
                curWord = words[cntr];
                text.text = curWord;
            }
            if(cntr == words.Length-1)
            {
                cntr = -1;
            }
        }   
    }
}
