using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NameDisplay : MonoBehaviour
{
    public string name;
    public Text txt;
    public float fadeTime;
    public bool display = false;
    GameObject getTarget;
    GameObject hitObject;
    public Vector3 mousePos;
    // Start is called before the first frame update
    void Start()
    {
        txt = this.GetComponentInChildren<Text>();
        txt.color = Color.clear;
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log("display : " + display);
        
        FadeText();
    }

    private void FadeText()
    {
        if (display)
        {
            txt.text = name;
            txt.color = Color.Lerp(txt.color, Color.black, fadeTime * Time.deltaTime);
        }
        else
        {
            txt.color = Color.Lerp(txt.color, Color.clear, fadeTime * Time.deltaTime);
        }
    }

    GameObject ReturnClickedObject(out RaycastHit hit)
    {
        GameObject target = null;
        //Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray.origin, ray.direction * 10, out hit))
        {
            target = hit.collider.gameObject;
        }
        return target;
    }
}
