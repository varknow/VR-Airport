using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RecordingScript : MonoBehaviour
{
    public GameObject Record1;
    public GameObject Record2;
    public GameObject Record3;
    public GameObject Record4;
    void Start()
    {
        Record1.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        Record1.SetActive(false);
        Record2.SetActive(true);
        Record2.SetActive(false);
        Record3.SetActive(true);
        Record3.SetActive(false);
        Record4.SetActive(true);
        Record4.SetActive(false);

    }
}
