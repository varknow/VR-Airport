using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VarknowAgent_second : MonoBehaviour
{
    public KeyCode AppearKey = KeyCode.E;
    public KeyCode StartDialougeKey = KeyCode.E;
    
    public GameObject Avatar;
    
    public Text HintTextBox;
    public Text AdditionalHintTextBox;
    
    public Transform PlayerToLook;
    public Transform[] SpawnPointsList;
    private int SpawnPointIndex;
    
    public Animator animator;
    public string DisappearAnimTrigger = "disappear";
    public string AppearAnimTrigger = "appear";
    
    private HintSystem hintSystem;

    private bool OnHint;
    private Transform SpawnPoint; //...
    public Canvas canvas;
 
    
    

    public void SetNewSpawnPoint(int index = 0) //...
    {
        SpawnPoint = SpawnPointsList[index];
    }
    
    private void Start()
    {
        SetNewSpawnPoint(); //...
        hintSystem = FindObjectOfType<HintSystem>();
        Canvas canvas = this.GetComponentInChildren<Canvas>();
    }

    // Update is called once per frame
    void Update()
    {
//        Vector3 targetPosition = new Vector3( PlayerToLook.position.x, 
//            transform.position.y, 
//            PlayerToLook.position.z ) ;
//        transform.LookAt(targetPosition);
        if (Input.GetKeyDown(AppearKey))
        {
            Appear();
        }
    }


    private IEnumerator TypeSentence (string sentence, Text dialogueText)
    {
        var animTime = 0.01f;
        if (sentence.Length > 100)
        {
            animTime = 0.005f;
        } 
        
        dialogueText.text = "";
        foreach (char letter in sentence.ToCharArray())
        {
            dialogueText.text += letter;
            yield return null;
//            yield return new WaitForSeconds(animTime); 
        }
    }
    public void Appear()
    {
        OnHint = true;
        transform.position = SpawnPoint.position;
//        animator.SetTrigger(AppearAnimTrigger);        
        //Avatar.SetActive(true);
        
        transform.parent = SpawnPoint;
        transform.localPosition = Vector3.zero;
        transform.rotation = SpawnPoint.rotation;
        canvas.gameObject.SetActive(true);
        canvas.transform.LookAt(PlayerToLook);
        canvas.transform.eulerAngles = new Vector3(0, canvas.transform.rotation.eulerAngles.y, 0);


        GetCurrentHint();
        

    }

    public void Disappear()
    {
        OnHint = false;
        canvas.gameObject.SetActive(false);

//        animator.SetTrigger(DisappearAnimTrigger);        
        //Avatar.SetActive(false);
    }
    public void GetCurrentHint()
    {
        try
        {
            var hint = hintSystem.GetHint();
            StopCoroutine("TypeSentence");
            StartCoroutine(TypeSentence(hint, HintTextBox));

        }
        catch (Exception e)
        {
            Debug.Log(e.Message);
        }
        
        

            
    }

    public void GetCurrentAdditionalHint()
    {
        StopCoroutine("TypeSentence");
        StartCoroutine(TypeSentence(hintSystem.GetOneAdditionalHints(), AdditionalHintTextBox));
    }


}
