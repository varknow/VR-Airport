using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CrazyMinnow.SALSA;

public class AssignVoice : MonoBehaviour
{
    public AudioSource source;
    public Salsa3D salsa;
    // Start is called before the first frame update
    void Start()
    {
        //salsa = GameObject.Find("GameObjectWithSalsaComponent").GetComponent();
        //salsa = this.GetComponent(Salsa3D);
        salsa = (Salsa3D)FindObjectOfType(typeof(Salsa3D));


    }

    // Update is called once per frame
    void Update()
    {
        if (source.isPlaying)
        {
            salsa.SetAudioClip(source.clip);
        }
    }
}
