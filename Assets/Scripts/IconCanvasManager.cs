using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IconCanvasManager : MonoBehaviour
{
    public GameObject RecordingIcon;
    public GameObject CorrectIcon;
    public GameObject WrongIcon;
    public GameObject StartIcon;


    public void ShowCorrectIcon()
    {
        
        RecordingIcon.SetActive(false);
        WrongIcon.SetActive(false);
        StartIcon.SetActive(false);
        CorrectIcon.SetActive(true);
        
    }
    public void ShowWrongIcon()
    {
        
        RecordingIcon.SetActive(false);
        WrongIcon.SetActive(false);
        StartIcon.SetActive(false);
        CorrectIcon.SetActive(true);
        
    }
    public void ShowStartIcon()
    {
        
        RecordingIcon.SetActive(false);
        WrongIcon.SetActive(false);
        StartIcon.SetActive(false);
        CorrectIcon.SetActive(true);
        
    }
    public void ShowCorrectRecordingIcon()
    {   
        RecordingIcon.SetActive(false);
        WrongIcon.SetActive(false);
        StartIcon.SetActive(false);
        CorrectIcon.SetActive(true);
    }

    public void DisableAllIcons()
    {
        RecordingIcon.SetActive(false);
        WrongIcon.SetActive(false);
        StartIcon.SetActive(false);
        CorrectIcon.SetActive(false);
    }

}
